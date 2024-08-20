using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Level.Config;
using Code.Gameplay.Features.LevelTasks.Config;
using Code.Gameplay.Levels;
using Code.Gameplay.Sounds.Config;
using Code.Gameplay.Sounds.Service;
using Code.Gameplay.StaticData;
using Code.Gameplay.Windows.Base;
using Code.Gameplay.Windows.Service;
using Code.Gameplay.Windows.Windows.Game;
using Code.Gameplay.Windows.Windows.Game.Factory;
using Code.Infrastructure.Loading;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using Code.Progress.Provider;
using Code.Progress.SaveLoad;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Gameplay.Windows.Windows.HomeScreen
{
    public class LevelInfoWindow : BaseWindow
    {
        public Transform AnimationContent;
        public float ScaleInDuration = 1f;
        public float ScaleOutDuration = 0.5f;
        
        public Button CloseButton;
        public Button StartLevelButton;
        public Button CompleteLevelButton;
        
        public RectTransform RabbitGoalParent;
        public GameObject TimeTextArea;
        public TextMeshProUGUI TimeText;
        public GameObject HoldTextArea;  
        public TextMeshProUGUI HoldText;

        public string LevelId;

        private ILevelDataProvider _levelDataProvider;
        private IGameStateMachine _gameStateMachine;
        private IStaticDataService _staticDataService;
        private IWindowService _windowService;
        private IAudioService _audioService;
        private IUITaskFactory _taskFactory;
        private ISaveLoadService _saveLoadService;
        private IProgressProvider _progressProvider;

        [Inject]
        private void Construct(
            IWindowService windowService,
            IStaticDataService staticDataService,
            IGameStateMachine gameStateMachine,
            ILevelDataProvider levelDataProvider,
            IAudioService audioService,
            IUITaskFactory taskFactory,
            IProgressProvider progressProvider,
            ISaveLoadService saveLoadService)
        {
            _progressProvider = progressProvider;
            _saveLoadService = saveLoadService;
            _taskFactory = taskFactory;
            _audioService = audioService;
            _levelDataProvider = levelDataProvider;
            _gameStateMachine = gameStateMachine;
            _staticDataService = staticDataService;
            _windowService = windowService;
        }
        
        protected override void Initialize()
        {
            base.Initialize();
            Id = WindowId.LevelInfo;
            
            AnimationContent.localScale = Vector3.zero;
            AnimationContent.DOScale(Vector3.one, ScaleInDuration).SetEase(Ease.InOutSine);
        }
        
        protected override void SubscribeUpdates()
        {
            base.SubscribeUpdates();
            CloseButton.onClick.AddListener(Close);
            StartLevelButton.onClick.AddListener(StartLevel);
            CompleteLevelButton.onClick.AddListener(SkipLevel);
        }

        protected override void UnsubscribeUpdates()
        {
            base.UnsubscribeUpdates();
            CloseButton.onClick.RemoveListener(Close);
            StartLevelButton.onClick.RemoveListener(StartLevel);
            CompleteLevelButton.onClick.RemoveListener(SkipLevel);
        }

        public void SetData(string levelId, bool isCompleted)
        {
            LevelId = levelId;
            
            CompleteLevelButton.gameObject.SetActive(isCompleted == false);

            LevelTaskConfig taskConfig = _staticDataService.GetLevelConfig(levelId).TaskConfig;

            if (taskConfig.TaskType == LevelTaskType.ConcreteRabbitAmount)
                DisplayConcreteRabbitsGoal(taskConfig.TaskGoalsByRabbitColor, taskConfig.AmountCondition);
            else if (taskConfig.TaskType == LevelTaskType.CommonRabbitAmount)
                DisplayCommonRabbitsGoal(taskConfig.MinAmount, taskConfig.MaxAmount, taskConfig.AmountCondition);
            else if (taskConfig.TaskType == LevelTaskType.RemoveAllRabbits)
                DisplayRemoveAllRabbitsGoal();

            foreach (LevelTaskDurationLimitationType limitationType in taskConfig.DurationLimitation)
            {
                if (limitationType == LevelTaskDurationLimitationType.TimeDuration)
                {
                    TimeTextArea.SetActive(true);
                    TimeText.text = taskConfig.TaskDurationTime.FinishIn();
                }
                else if (limitationType == LevelTaskDurationLimitationType.HoldDuration)
                {
                    HoldTextArea.SetActive(true);
                    HoldText.text = taskConfig.TimeToHold.HoldAmount();
                } 
            }
        }

        private void DisplayConcreteRabbitsGoal(List<TaskGoalByRabbitColor> goals, LevelTaskAmountConditionType amountCondition)
        {
            foreach (TaskGoalByRabbitColor goalByRabbitColor in goals)
            {
                RabbitTaskGoalPartView goalPartView = _taskFactory.RabbitTaskGoalPartView(RabbitGoalParent);
                
                if (amountCondition == LevelTaskAmountConditionType.MinAmount)
                    goalPartView.InitializeAsConcreteWithMinAmount(goalByRabbitColor.ColorType, goalByRabbitColor.MinAmount);
                else
                    goalPartView.InitializeAsConcreteWithRangeAmount(goalByRabbitColor.ColorType, goalByRabbitColor.MinAmount,  goalByRabbitColor.MaxAmount);
                
                goalPartView.DisplayDescription(LevelId);
            }
        }

        private void DisplayCommonRabbitsGoal(int minAmount, int maxAmount, LevelTaskAmountConditionType amountCondition)
        {
            RabbitTaskGoalPartView goalPartView = _taskFactory.RabbitTaskGoalPartView(RabbitGoalParent);
                
            if (amountCondition == LevelTaskAmountConditionType.MinAmount)
                goalPartView.InitializeAsCommonWithMinAmount(minAmount);
            else
                goalPartView.InitializeAsCommonWithRangeAmount(minAmount,  maxAmount);
            
            goalPartView.DisplayDescription(LevelId);
        }

        private void DisplayRemoveAllRabbitsGoal()
        {
            RabbitTaskGoalPartView goalPartView = _taskFactory.RabbitTaskGoalPartView(RabbitGoalParent);
            goalPartView.InitializeAsKillAll();
            
            goalPartView.DisplayDescription(LevelId);
        }

        private void Close()
        {
            _audioService.PlayAudio(SoundType.UIClick);
            _windowService.Close(Id);
            
            AnimationContent.DOScale(Vector3.zero, ScaleOutDuration).SetEase(Ease.InOutSine);
        }

        private void StartLevel()
        {
            _audioService.PlayAudio(SoundType.UIClick);
            _levelDataProvider.SetCurrentId(LevelId);
            _gameStateMachine.Enter<LoadingBattleState, string>(Scenes.GameScene);
        }

        private void SkipLevel()
        {
            _audioService.PlayAudio(SoundType.UIClick);
            
            _progressProvider.ProgressData.PassedLevels.Add(LevelId);
            _saveLoadService.SaveProgress();

            _windowService.Close(WindowId.GameLevels);
            _windowService.Open(WindowId.GameLevels);

            _windowService.Close(Id);
            
            AnimationContent.DOScale(Vector3.zero, ScaleOutDuration).SetEase(Ease.InOutSine);
        }
    }
}
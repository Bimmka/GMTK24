using System;
using System.Collections.Generic;
using Code.Gameplay.Features.LevelTasks.Config;
using Code.Gameplay.Features.Rabbits.Config.Rabbits;
using Code.Gameplay.Levels;
using Code.Gameplay.StaticData;
using Code.Gameplay.Windows.Windows.Game.Factory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Gameplay.Windows.Windows.Game
{
    public class GameTaskStatusPanel : MonoBehaviour
    {
        public GameObject TimeLeftArea;
        public Image TimeLeft;
        
        public GameObject HoldTimeArea;
        public Image HoldTime;
        
        public GameObject CommonRabbitArea;
        public GameObject KillCommonRabbitsIcon;
        public TextMeshProUGUI CommonAmountText;

        public RectTransform ConcreteRabbitAmountSpawnParent;

        private readonly List<ConcreteRabbitAmountView> _concreteRabbitAmountViews = new List<ConcreteRabbitAmountView>();

        private IStaticDataService _staticDataService;
        private ILevelDataProvider _levelDataProvider;
        private IUITaskFactory _factory;
        
        private bool _wasInitialized = false;

        [Inject]
        private void Construct(IStaticDataService staticDataService, ILevelDataProvider levelDataProvider, IUITaskFactory factory)
        {
            _factory = factory;
            _levelDataProvider = levelDataProvider;
            _staticDataService = staticDataService;
        }

        public void Initialize()
        {
            LevelTaskConfig taskConfig = _staticDataService.GetLevelConfig(_levelDataProvider.CurrentId).TaskConfig;

            if (taskConfig.TaskType == LevelTaskType.ConcreteRabbitAmount)
            {
                foreach (TaskGoalByRabbitColor goalByRabbitColor in taskConfig.TaskGoalsByRabbitColor)
                {
                    ConcreteRabbitAmountView view = _factory.CreateConcreteRabbitAmountView(ConcreteRabbitAmountSpawnParent);

                    view.Initialize(goalByRabbitColor.ColorType, 0);
                    
                    _concreteRabbitAmountViews.Add(view);
                }
            }
            else
            {
                CommonRabbitArea.SetActive(true);
                CommonAmountText.text = String.Empty;
                
                KillCommonRabbitsIcon.SetActive(taskConfig.TaskType == LevelTaskType.RemoveAllRabbits);
            }

            foreach (LevelTaskDurationLimitationType durationLimitationType in taskConfig.DurationLimitation)
            {
                if (durationLimitationType == LevelTaskDurationLimitationType.TimeDuration)
                    TimeLeftArea.SetActive(true);
                else if (durationLimitationType == LevelTaskDurationLimitationType.HoldDuration)
                    HoldTimeArea.SetActive(true);
            }

            _wasInitialized = true;
        }
        
        public void UpdateByEntity(GameEntity task)
        {
            if (_wasInitialized == false)
                return;
            
            if (task.isUncompleted == false)
                return;

            if (task.isLevelTaskWithTimeForFail)
            {
                TimeLeft.fillAmount = task.LevelTaskDurationBeforeExpiredTimeLeft / task.LevelTaskDurationBeforeExpired;
            }
            
            if (task.isLevelTaskWithHoldDuration)
            {
                HoldTime.fillAmount = task.LevelTaskTargetHoldDurationTime / task.LevelTaskTargetHoldDuration;
            }
            
            if (task.isLevelTaskConcreteRabbitAmount)
            {
                foreach ((RabbitColorType color,int amount) in task.LevelTaskCurrentConcreteRabbitsAmount)
                {
                    foreach (ConcreteRabbitAmountView amountView in _concreteRabbitAmountViews)
                    {
                        if (amountView.Color == color)
                        {
                            amountView.DisplayAmount(amount);
                            continue;
                        }
                    }
                }
            }

            if (task.isLevelTaskCommonRabbitAmount || task.isLevelTaskRemoveAllRabbits)
            {
                CommonAmountText.text = task.LevelTaskCurrentCommonAmount.ToString();
            }
        }
    }
}
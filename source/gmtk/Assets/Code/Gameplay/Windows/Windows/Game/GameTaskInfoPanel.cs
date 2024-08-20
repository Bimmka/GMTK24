using System.Collections.Generic;
using Code.Gameplay.Features.LevelTasks.Config;
using Code.Gameplay.Levels;
using Code.Gameplay.StaticData;
using Code.Gameplay.Windows.Windows.Game.Factory;
using Code.Gameplay.Windows.Windows.HomeScreen;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Windows.Windows.Game
{
    public class GameTaskInfoPanel : MonoBehaviour
    {
        public RectTransform RabbitGoalParent;
        public GameObject TimeTextArea;
        public TextMeshProUGUI TimeText;
        public GameObject HoldTextArea;  
        public TextMeshProUGUI HoldText;
        
        private IStaticDataService _staticDataService;
        private IUITaskFactory _taskFactory;
        private ILevelDataProvider _levelDataProvider;

        [Inject]
        private void Construct(IStaticDataService staticDataService, IUITaskFactory taskFactory, ILevelDataProvider levelDataProvider)
        {
            _levelDataProvider = levelDataProvider;
            _taskFactory = taskFactory;
            _staticDataService = staticDataService;
        }
        
         public void SetData(string levelId)
        {
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
                RabbitTaskGoalPartViewInGame goalPartView = _taskFactory.RabbitTaskGoalPartViewInGame(RabbitGoalParent);
                
                if (amountCondition == LevelTaskAmountConditionType.MinAmount)
                    goalPartView.InitializeAsConcreteWithMinAmount(goalByRabbitColor.ColorType, goalByRabbitColor.MinAmount);
                else
                    goalPartView.InitializeAsConcreteWithRangeAmount(goalByRabbitColor.ColorType, goalByRabbitColor.MinAmount,  goalByRabbitColor.MaxAmount);
                
                goalPartView.DisplayDescription(_levelDataProvider.CurrentId);
            }
        }

        private void DisplayCommonRabbitsGoal(int minAmount, int maxAmount, LevelTaskAmountConditionType amountCondition)
        {
            RabbitTaskGoalPartViewInGame goalPartView = _taskFactory.RabbitTaskGoalPartViewInGame(RabbitGoalParent);
                
            if (amountCondition == LevelTaskAmountConditionType.MinAmount)
                goalPartView.InitializeAsCommonWithMinAmount(minAmount);
            else
                goalPartView.InitializeAsCommonWithRangeAmount(minAmount,  maxAmount);
            
            goalPartView.DisplayDescription(_levelDataProvider.CurrentId);
        }

        private void DisplayRemoveAllRabbitsGoal()
        {
            RabbitTaskGoalPartViewInGame goalPartView = _taskFactory.RabbitTaskGoalPartViewInGame(RabbitGoalParent);
            goalPartView.InitializeAsKillAll();
            goalPartView.DisplayDescription(_levelDataProvider.CurrentId);
        }
    }
}
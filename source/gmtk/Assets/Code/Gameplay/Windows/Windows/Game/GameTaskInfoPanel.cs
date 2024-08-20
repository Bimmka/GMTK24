using System.Collections.Generic;
using Code.Gameplay.Features.LevelTasks.Config;
using Code.Gameplay.StaticData;
using Code.Gameplay.Windows.Windows.Game.Factory;
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

        [Inject]
        private void Construct(IStaticDataService staticDataService, IUITaskFactory taskFactory)
        {
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
                    TimeText.text = $"Finish before {taskConfig.TaskDurationTime:#}";
                }
                else if (limitationType == LevelTaskDurationLimitationType.HoldDuration)
                {
                    HoldTextArea.SetActive(true);
                    HoldText.text = $"Hold this amount for {taskConfig.TimeToHold:#}";
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
            }
        }

        private void DisplayCommonRabbitsGoal(int minAmount, int maxAmount, LevelTaskAmountConditionType amountCondition)
        {
            RabbitTaskGoalPartView goalPartView = _taskFactory.RabbitTaskGoalPartView(RabbitGoalParent);
                
            if (amountCondition == LevelTaskAmountConditionType.MinAmount)
                goalPartView.InitializeAsCommonWithMinAmount(minAmount);
            else
                goalPartView.InitializeAsCommonWithRangeAmount(minAmount,  maxAmount);
        }

        private void DisplayRemoveAllRabbitsGoal()
        {
            RabbitTaskGoalPartView goalPartView = _taskFactory.RabbitTaskGoalPartView(RabbitGoalParent);
            goalPartView.InitializeAsKillAll();
        }
    }
}
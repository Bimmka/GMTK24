using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.LevelTasks.Config
{
    [Serializable]
    public class LevelTaskConfig
    {
        public LevelTaskType TaskType;
        public LevelTaskDurationLimitationType[] DurationLimitation;
        public LevelTaskAmountConditionType AmountCondition;
        
        [Header("For ConcreteRabbitAmount")]
        public List<TaskGoalByRabbitColor> TaskGoalsByRabbitColor;
        
        [Header("For TimeDuration")]
        public float TaskDurationTime;
        
        [Header("For HoldDuration")]
        public float TimeToHold;

        [Header("For CommonRabbitAmount")]
        public int MinAmount;
        public int MaxAmount;
        
        [TextArea(0,10)]
        public string Description;
    }
}
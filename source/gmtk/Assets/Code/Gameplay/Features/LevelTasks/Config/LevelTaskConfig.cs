using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.LevelTasks.Config
{
    [Serializable]
    public class LevelTaskConfig
    {
        public string Id;
        public string Description;
        public string Name;
        public Sprite Icon;
        
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
    }
}
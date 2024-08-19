using System;
using System.Collections.Generic;
using Code.Gameplay.Features.Rabbits.Config.Rabbits;
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

        public List<RabbitColorType> RabbitColors;
        public List<TaskGoalByRabbitColor> TaskGoalsByRabbitColor;
        
        public float TaskDurationTime;
        
        public float TimeToHold;

        public int MinAmount;
        public int MaxAmount;
    }
}
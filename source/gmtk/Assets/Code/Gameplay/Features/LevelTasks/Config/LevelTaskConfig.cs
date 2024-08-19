using System;
using System.Collections.Generic;
using Code.Gameplay.Features.Rabbits.Config.Rabbits;
using UnityEngine;
using UnityEngine.Serialization;

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
        public TakeIntoRabbitColorType ConsiderRabbitColorType;

        public List<RabbitColorType> RabbitColors;
        public float TaskDurationTime;
        public float TimeToHold;
        public int MinAmount;
        public int MaxAmount;
    }
}
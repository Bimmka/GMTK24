using System;
using Code.Gameplay.Features.Rabbits.Config.Rabbits;

namespace Code.Gameplay.Features.LevelTasks.Config
{
    [Serializable]
    public class TaskGoalByRabbitColor
    {
        public RabbitColorType ColorType;
        public int MinAmount;
        public int MaxAmount;
    }
    
    [Serializable]
    public class TaskAmountByRabbitColor
    {
        public RabbitColorType ColorType;
        public int CurrentAmount;
    }
}
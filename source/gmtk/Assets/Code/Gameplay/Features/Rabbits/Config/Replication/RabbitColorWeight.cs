using System;
using Code.Gameplay.Features.Rabbits.Config.Rabbits;

namespace Code.Gameplay.Features.Rabbits.Config.Replication
{
    [Serializable]
    public struct RabbitColorWeight
    {
        public RabbitColorType ColorType;
        public float Weight;
    }
}
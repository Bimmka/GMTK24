using System;
using Code.Gameplay.Features.Rabbits.Config.Rabbits;

namespace Code.Gameplay.Features.Rabbits.Config.Replication
{
    [Serializable]
    public struct ColorMixing
    {
        public RabbitColorType FirstColorType;
        public RabbitColorType SecondColorType;
        public RabbitColorType ResultColorType;
    }
}
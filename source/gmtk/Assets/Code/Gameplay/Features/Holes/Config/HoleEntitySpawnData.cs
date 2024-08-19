using System;
using Code.Gameplay.Features.Rabbits.Config.Rabbits;

namespace Code.Gameplay.Features.Holes.Config
{
    [Serializable]
    public struct HoleEntitySpawnData
    {
        public SpawnEntityType SpawnType;
        public RabbitColorType[] RabbitColorTypes;
        public float Chance;
    }
}
using System;
using Code.Gameplay.Features.Rabbits.Config.Rabbits;

namespace Code.Gameplay.Features.Holes.Config
{
    [Serializable]
    public struct HoleEntityConfigSpawnData
    {
        public SpawnEntityType SpawnType;
        public RabbitColorType[] RabbitColorTypes;
        public float MinChance;
        public float MaxChance;
    }
}
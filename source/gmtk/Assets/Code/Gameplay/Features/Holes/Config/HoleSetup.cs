using System;
using Code.Infrastructure.View;

namespace Code.Gameplay.Features.Holes.Config
{
    [Serializable]
    public class HoleSetup
    {
        public EntityBehaviour View;

        public float MinSpawnInterval;
        public float MaxSpawnInterval;

        public HoleEntityConfigSpawnData[] HoleEntityConfigSpawnData;
    }
}
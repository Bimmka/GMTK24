using System;
using Code.Gameplay.Features.Infections.Configs;

namespace Code.Gameplay.Features.Level.Config
{
    [Serializable]
    public class InfectionForLevelData
    {
        public InfectionType Type;
        public float Interval;
    }
}
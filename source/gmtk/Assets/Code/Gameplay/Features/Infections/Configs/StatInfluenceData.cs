using System;
using Code.Gameplay.Features.CharacterStats;

namespace Code.Gameplay.Features.Infections.Configs
{
    [Serializable]
    public struct StatInfluenceData
    {
        public Stats StatType;
        public float EffectValue;
        public float Duration;
    }
}
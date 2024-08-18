using System;
using UnityEngine;

namespace Code.Gameplay.Features.Infections.Configs
{
    [Serializable]
    public class InfectionSetup 
    {
        public InfectionType Type;

        public float ChanceToInfect = 1f;
        public float TimeBeforeDeath = 10f;
        public float InfectPeriod = 1f;
        public LayerMask InfectMask;
        public float Radius = 1f;

        public float EffectValue;
    }
}
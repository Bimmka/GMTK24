using System;
using Code.Gameplay.VFX.Behaviours;
using UnityEngine;

namespace Code.Gameplay.VFX.Config
{
    [Serializable]
    public class VFXContainer
    {
        public VFXType Type;
        public VFXElement Particle;
        public float DefaultDuration;
    }
}
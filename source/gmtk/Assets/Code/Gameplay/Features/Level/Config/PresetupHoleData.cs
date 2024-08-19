using System;
using Code.Gameplay.Features.Holes.Config;
using UnityEngine;

namespace Code.Gameplay.Features.Level.Config
{
    [Serializable]
    public class PresetupHoleData
    {
        public Vector3 At;
        public int StallIndex;
        public HoleSetup Setup;
    }
}
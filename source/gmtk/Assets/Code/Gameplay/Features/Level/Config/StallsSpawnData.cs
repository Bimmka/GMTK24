using System;
using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Features.Level.Config
{
    [Serializable]
    public class StallsSpawnData
    {
        public EntityBehaviour View;
        public Vector3 SpawnPosition;
        public int Index;
        public Vector2 Bounds;
    }
}
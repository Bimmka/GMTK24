using System;
using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Features.Level.Config
{
    [Serializable]
    public class ConveyorBeltData
    {
        public EntityBehaviour View;
        
        public int StartStallIndex;
        public int EndStallIndex;
        
        public Vector3 StartPosition;
        public Vector3 EndPosition;
        
        public float Speed;

        public float InteractionRadius = 0.5f;
        public float InteractionInterval = 0.1f;
        public LayerMask TargetCollectionLayerMask;
    }
}
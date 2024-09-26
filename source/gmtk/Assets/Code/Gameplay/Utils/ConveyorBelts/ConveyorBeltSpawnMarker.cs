using System;
using Code.Infrastructure.View;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Code.Gameplay.Utils.ConveyorBelts
{
#if UNITY_EDITOR
    [ExecuteInEditMode]
#endif
    public class ConveyorBeltSpawnMarker : MonoBehaviour
    {
        public Transform StartPoint;
        public Transform EndPoint;

        public int StartStallIndex;
        public int EndStallIndex;

        public float Speed;

        public EntityBehaviour View;
        [ReadOnly] 
        public LayerMask InteractionLayerMask;
        [ReadOnly]
        public float InteractionInterval = 0.1f;
        [ReadOnly]
        public float InteractionRadius = 0.5f;
        

#if UNITY_EDITOR
        private void Awake()
        {
            InteractionLayerMask = LayerMask.NameToLayer("ConveyorBelt");
            InteractionInterval = 0.1f;
            InteractionRadius = 0.5f;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(StartPoint.position, 0.5f);
            Gizmos.DrawWireSphere(StartPoint.position, 0.01f);
            
            Gizmos.DrawWireSphere(EndPoint.position, 0.5f);
            Gizmos.DrawWireSphere(EndPoint.position, 0.01f);
        }

        public void OnDrawGizmosSelected()
        {
            Gizmos.DrawLine(StartPoint.position, EndPoint.position);
            Gizmos.DrawLine(EndPoint.position, EndPoint.position - Vector3.one * 0.3f);
            Gizmos.DrawLine(EndPoint.position, EndPoint.position - new Vector3(0.3f, -0.3f));
        }
#endif
    }
}
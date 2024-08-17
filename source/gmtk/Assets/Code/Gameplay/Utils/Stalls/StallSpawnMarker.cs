using System;
using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Utils.Stalls
{
    public class StallSpawnMarker : MonoBehaviour
    {
        public EntityBehaviour View;
        public Vector2 Bounds;
        public int Index;
        public Color DisplayColor = Color.red;

        public void OnDrawGizmos()
        {
            Gizmos.color = DisplayColor;
            Gizmos.DrawWireCube(transform.position, new Vector3(Bounds.x, 0, Bounds.y));
        }
    }
}
using Code.Gameplay.Features.Holes.Config;
using UnityEngine;

namespace Code.Gameplay.Utils.Holes
{
    public class HoleSpawnMarker : MonoBehaviour
    {
        public HoleSetup Setup;
        public int StallIndex;
        public Color DisplayColor = Color.red;

        public void OnDrawGizmos()
        {
            Gizmos.color = DisplayColor;
            Gizmos.DrawWireSphere(transform.position, 1f);
        }
    }
}
using UnityEngine;

namespace Code.Gameplay.Utils.ConveyorBelts
{
    public class ConveyorBeltPoint : MonoBehaviour
    {
        public ConveyorBeltSpawnMarker Marker;

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Marker.OnDrawGizmosSelected();
        }
#endif
    }
}
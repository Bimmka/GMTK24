using UnityEngine;

namespace Code.Gameplay.Features.Rabbits.Behaviours.Visuals
{
    public class RabbitVisualChanger : MonoBehaviour
    {
        public SpriteRenderer SpriteRenderer;
        public Color SelectedColor;
        public Color UnselectedColor;
        public Color ReplicationColor;
        public Color WaitingTargetColor;
        
        public void ApplySelectionStatus(bool isSelected)
        {
            SpriteRenderer.color = isSelected ? SelectedColor : UnselectedColor;
        }

        public void SetReplicating()
        {
            SpriteRenderer.color = ReplicationColor;
        }

        public void UnsetReplicating()
        {
            SpriteRenderer.color = UnselectedColor;
        }

        public void SetWaitTarget(bool isWaitingTarget)
        {
            SpriteRenderer.color = isWaitingTarget ? WaitingTargetColor : UnselectedColor;
        }
    }
}
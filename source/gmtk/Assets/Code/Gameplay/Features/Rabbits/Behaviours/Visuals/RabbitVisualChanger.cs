using UnityEngine;

namespace Code.Gameplay.Features.Rabbits.Behaviours.Visuals
{
    public class RabbitVisualChanger : MonoBehaviour
    {
        public SpriteRenderer SpriteRenderer;
        public Color SelectedColor;
        public Color UnselectedColor;
        
        public void ApplySelectionStatus(bool isSelected)
        {
            SpriteRenderer.color = isSelected ? SelectedColor : UnselectedColor;
        }
    }
}
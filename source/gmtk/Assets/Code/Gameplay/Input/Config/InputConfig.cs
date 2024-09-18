using UnityEngine;

namespace Code.Gameplay.Input.Config
{
    [CreateAssetMenu(menuName = "StaticData/Input/Create Input Config", fileName = "InputConfig")]
    public class InputConfig : ScriptableObject
    {
        public float IntervalForClick = 0.1f;
        public float IntervalForLongTap = 0.3f;
        public float PositionShiftForDragStart = 1f;
        public LayerMask ClickableLayerMask;
    }
}
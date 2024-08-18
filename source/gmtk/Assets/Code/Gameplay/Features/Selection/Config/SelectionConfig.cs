using UnityEngine;

namespace Code.Gameplay.Features.Selection.Config
{
    [CreateAssetMenu(menuName = "StaticData/Selection/Create Selection Config", fileName = "SelectionConfig")]
    public class SelectionConfig : ScriptableObject
    {
        public float FollowSelectionCenterSpeed = 10f;
        public float MoveToAfterDragPositionSpeed = 5f;
        public LayerMask SelectionMask;
        public float SelectionRadius = 1.5f;
    }
}
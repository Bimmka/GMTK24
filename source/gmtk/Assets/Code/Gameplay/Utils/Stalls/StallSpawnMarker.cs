using System;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.Utils.Stalls
{
    [ExecuteInEditMode]
    public class StallSpawnMarker : MonoBehaviour
    {
        public Vector2 Bounds;
        [OnValueChanged(nameof(DisplayStallIndex))]
        public int Index;
        public Color DisplayColor = Color.red;
        public TextMeshProUGUI IndexText;

        private void Awake()
        {
            DisplayStallIndex();    
        }

        public void OnDrawGizmos()
        {
            Gizmos.color = DisplayColor;
            Gizmos.DrawWireCube(transform.position, new Vector3(Bounds.x, Bounds.y, 0));
        }

        public void DisplayStallIndex()
        {
            IndexText.text = Index.ToString();
            IndexText.Rebuild(CanvasUpdate.LatePreRender);
        }
    }
}
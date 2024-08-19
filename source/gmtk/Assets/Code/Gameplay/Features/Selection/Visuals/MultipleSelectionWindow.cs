using Code.Gameplay.Windows;
using Code.Gameplay.Windows.Base;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Code.Gameplay.Features.Selection.Visuals
{
    public class MultipleSelectionWindow : BaseWindow
    {
        public RectTransform Selection;

        protected override void Initialize()
        {
            base.Initialize();
            Id = WindowId.MultipleSelection;
            Selection.gameObject.SetActive(false);
        }

        public void Display(Vector2 startPoint, Vector2 endPoint)
        {
            if (Selection.gameObject.activeSelf == false)
                Selection.gameObject.SetActive(true);
            
            Vector2 selectionAreaCenter = (startPoint + endPoint) / 2;
            Vector2 selectionBounds = new Vector2(
                Mathf.Abs(startPoint.x - endPoint.x),
                Mathf.Abs(startPoint.y - endPoint.y));

            Selection.position = selectionAreaCenter;
            Selection.sizeDelta = selectionBounds;
        }

        public void Hide()
        {
            Selection.gameObject.SetActive(false);
            Selection.sizeDelta = Vector2.zero;
        }
    }
}
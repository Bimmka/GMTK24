using System;
using DG.Tweening;
using UnityEngine;

namespace Code.Gameplay.Windows.Windows.Loading
{
    public class LoadingCurtain : MonoBehaviour
    {
        public CanvasGroup CanvasGroup;
        public float HideDuration = 0.75f;
        public float ShowDuration = 0.75f;

        public void Hide(Action onFinished = null)
        {
            CanvasGroup.alpha = 1f;
            CanvasGroup.DOFade(0f, HideDuration).SetEase(Ease.Linear).OnComplete(() =>
            {
                onFinished?.Invoke();
                gameObject.SetActive(false);
            });
        }

        public void Show(Action onFinished = null)
        {
            CanvasGroup.alpha = 0f;
            gameObject.SetActive(true);
            CanvasGroup.DOFade(1f, ShowDuration).SetEase(Ease.Linear).OnComplete(() =>
            {
                onFinished?.Invoke();
            });
        }
    }
}
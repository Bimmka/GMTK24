using System;
using DG.Tweening;
using UnityEngine;

namespace Code.Gameplay.Sounds.Behaviours
{
    public class MainThemeSoundsContainer : MonoBehaviour
    {
        public AudioSource MainThemeSource;

        public void PlayMainTheme(AudioClip mainTheme, float endVolume)
        {
            MainThemeSource.clip = mainTheme;
            MainThemeSource.volume = endVolume;
            MainThemeSource.Play();
        }

        public void PlayMainThemeWithTransition(AudioClip newMainTheme, float duration, float endVolume)
        {
            if (MainThemeSource.clip != null || MainThemeSource.volume == 0 || MainThemeSource.isPlaying == false)
            {
                MainThemeSource.DOFade(0, duration).SetEase(Ease.InOutSine).OnComplete(() =>
                {
                    MainThemeSource.clip = newMainTheme;
                    MainThemeSource.Play();
                    MainThemeSource.DOFade(endVolume, duration).SetEase(Ease.InOutSine);
                });
            }
            else
            {
                MainThemeSource.clip = newMainTheme;
                MainThemeSource.Play();
            }
        }
    }
}
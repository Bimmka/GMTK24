using Code.Gameplay.Sounds.Behaviours;
using Code.Gameplay.Sounds.Config;

namespace Code.Gameplay.Sounds.Service
{
    public interface IAudioService
    {
        void PlayAudio(SoundType type);
        void PlayMainThemeWithTransitDuration(SoundType type, float duration);
        void Return(SoundElement element);
        float MainSoundVolume { get;}
        float SoundsVolume { get; }
        float EffectsVolume { get; }
        void SavePreferences();
        void ChangeMainVolume(float value);
        void ChangeEffectsVolume(float value);
        void ChangeSoundsVolume(float value);
        void UpdateParameters();
    }
}
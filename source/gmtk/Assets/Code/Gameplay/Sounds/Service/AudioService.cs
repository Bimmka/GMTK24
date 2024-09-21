using System.Collections.Generic;
using Code.Gameplay.Sounds.Behaviours;
using Code.Gameplay.Sounds.Config;
using Code.Gameplay.Sounds.Factory;
using Code.Gameplay.StaticData;
using Code.Progress.SaveLoad;
using UnityEngine.Audio;

namespace Code.Gameplay.Sounds.Service
{
    public class AudioService : IAudioService
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IAudioFactory _audioFactory;
        private readonly MainThemeSoundsContainer _mainThemeSoundsContainer;
        private readonly ISaveLoadService _saveLoadService;
        private readonly SoundMixerConfig _soundMixerConfig;
        private readonly AudioMixer _mainMixer;

        private readonly Queue<SoundElement> _savedSounds = new Queue<SoundElement>();

        public float MainSoundVolume { get; private set; }
        public float SoundsVolume { get; private set; }
        public float EffectsVolume { get; private set; }

        public AudioService(IStaticDataService staticDataService, IAudioFactory audioFactory, MainThemeSoundsContainer mainThemeSoundsContainer, ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
            _staticDataService = staticDataService;
            _audioFactory = audioFactory;
            _mainThemeSoundsContainer = mainThemeSoundsContainer;
            _soundMixerConfig = staticDataService.GetSoundMixerConfig();
            _mainMixer = _soundMixerConfig.MainMixer;
        }

        public SoundElement PlayAudio(SoundType type)
        {
            SoundContainer container = _staticDataService.GetSoundData(type);
            
            SoundElement element;
            if (_savedSounds.Count > 0)
            {
                element = _savedSounds.Dequeue();
            }
            else
            {
                element = _audioFactory.Create(_mainThemeSoundsContainer.transform);
            }
            
            element.Initialize(type, container.Clip, container.MixerGroup, 1f, container.Duration, container.IsLoop, container.IsIgnoreTimeScale, container.IsInfinite);
            return element;
        }

        public void PlayMainTheme(SoundType type)
        {
            SoundContainer container = _staticDataService.GetSoundData(type);
            _mainThemeSoundsContainer.PlayMainTheme(container.Clip, container.DefaultVolume);
        }

        public void PlayMainThemeWithTransitDuration(SoundType type, float duration)
        {
            SoundContainer container = _staticDataService.GetSoundData(type);
            _mainThemeSoundsContainer.PlayMainThemeWithTransition(container.Clip, duration, container.DefaultVolume);
        }

        public void Return(SoundElement element)
        {
            _savedSounds.Enqueue(element);
        }

        public void ChangeMainVolume(float value)
        {
            _mainMixer.SetFloat(_soundMixerConfig.MainVolumeMixerParameter, value.MixerVolume());
            MainSoundVolume = value;
        }
        
        public void ChangeEffectsVolume(float value)
        {
            _mainMixer.SetFloat(_soundMixerConfig.EffectsVolumeMixerParameter, value.MixerVolume());
            EffectsVolume = value;
        }
        
        public void ChangeSoundsVolume(float value)
        {
            _mainMixer.SetFloat(_soundMixerConfig.SoundsVolumeMixerParameter, value.MixerVolume());
            SoundsVolume = value;
        }

        public void RestoreParameters(SavedAudioPreferences audioPreferences)
        {
            ChangeMainVolume(audioPreferences.MainSoundVolume);
            ChangeSoundsVolume(audioPreferences.SoundsVolume);
            ChangeEffectsVolume(audioPreferences.EffectsVolume);
        }
        
        public void SavePreferences()
        {
            _saveLoadService.SaveAudioPreferences(new SavedAudioPreferences()
            {
                MainSoundVolume = MainSoundVolume,
                SoundsVolume = SoundsVolume,
                EffectsVolume = EffectsVolume
            });
        }
    }
}
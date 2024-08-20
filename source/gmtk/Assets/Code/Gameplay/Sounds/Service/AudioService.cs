using System.Collections.Generic;
using Code.Gameplay.Sounds.Behaviours;
using Code.Gameplay.Sounds.Config;
using Code.Gameplay.Sounds.Factory;
using Code.Gameplay.StaticData;
using UnityEngine;
using UnityEngine.Audio;

namespace Code.Gameplay.Sounds.Service
{
    public class AudioService : IAudioService
    {
        private const string MainSoundVolumeSaveKey = "MainSound";
        private const string SoundsVolumeSaveKey = "Sound";
        private const string EffectsVolumeSaveKey = "Effects";
        private const string MainVolumeMixerParameter = "MasterVolume";
        private const string EffectsVolumeMixerParameter = "EffectsVolume";
        private const string SoundsVolumeMixerParameter = "SoundsVolume";
        private const float VolumeTransitionCoefficient = 100f;

        private readonly IStaticDataService _staticDataService;
        private readonly IAudioFactory _audioFactory;
        private readonly MainThemeSoundsContainer _mainThemeSoundsContainer;
        private readonly AudioMixer _mainMixer;

        private readonly Queue<SoundElement> _savedSounds = new Queue<SoundElement>();

        public float MainSoundVolume { get; private set; }
        public float SoundsVolume { get; private set; }
        public float EffectsVolume { get; private set; }

        public AudioService(IStaticDataService staticDataService, IAudioFactory audioFactory, MainThemeSoundsContainer mainThemeSoundsContainer, AudioMixer mainMixer)
        {
            _staticDataService = staticDataService;
            _audioFactory = audioFactory;
            _mainThemeSoundsContainer = mainThemeSoundsContainer;
            _mainMixer = mainMixer;
            LoadPreferences();
        }

        public void PlayAudio(SoundType type)
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
            
            element.Initialize(type, container.Clip, container.MixerGroup, 1f, container.Duration, container.IsLoop);
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
            _mainMixer.SetFloat(MainVolumeMixerParameter, MixerVolume(value));
            MainSoundVolume = value;
        }
        
        public void ChangeEffectsVolume(float value)
        {
            _mainMixer.SetFloat(EffectsVolumeMixerParameter, MixerVolume(value));
            EffectsVolume = value;
        }
        
        public void ChangeSoundsVolume(float value)
        {
            _mainMixer.SetFloat(SoundsVolumeMixerParameter, MixerVolume(value));
            SoundsVolume = value;
        }

        private float MixerVolume(float volume)
        {
            if (volume == 0)
                return -80;

            return Mathf.Log10(volume) * 20;
        }

        public void UpdateParameters()
        {
            ChangeMainVolume(MainSoundVolume);
            ChangeSoundsVolume(SoundsVolume);
            ChangeEffectsVolume(EffectsVolume);
        }
        
        public void SavePreferences()
        {
            PlayerPrefs.SetFloat(MainSoundVolumeSaveKey, MainSoundVolume);
            PlayerPrefs.SetFloat(SoundsVolumeSaveKey, SoundsVolume);
            PlayerPrefs.SetFloat(EffectsVolumeSaveKey, EffectsVolume);
            PlayerPrefs.Save();
        }

        private void LoadPreferences()
        {
            MainSoundVolume = PlayerPrefs.GetFloat(MainSoundVolumeSaveKey, 1);
            SoundsVolume = PlayerPrefs.GetFloat(SoundsVolumeSaveKey, 1);
            EffectsVolume = PlayerPrefs.GetFloat(EffectsVolumeSaveKey, 1);
            
            ChangeMainVolume(MainSoundVolume);
            ChangeSoundsVolume(SoundsVolume);
            ChangeEffectsVolume(EffectsVolume);
        }
    }
}
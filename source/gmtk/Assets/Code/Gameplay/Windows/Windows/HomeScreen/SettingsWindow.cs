using Code.Gameplay.Sounds.Config;
using Code.Gameplay.Sounds.Service;
using Code.Gameplay.Windows.Base;
using Code.Gameplay.Windows.Service;
using UnityEngine.UI;
using Zenject;

namespace Code.Gameplay.Windows.Windows.HomeScreen
{
    public class SettingsWindow : BaseWindow
    {
        public Slider MainVolumeSlider;
        public Slider EffectsVolumeSlider;
        public Slider SoundsVolumeSlider;

        public Button CloseButton;
        
        private IWindowService _windowService;
        private IAudioService _audioService;

        [Inject]
        private void Construct(IWindowService windowService, IAudioService audioService)
        {
            _audioService = audioService;
            _windowService = windowService;
        }
        
        protected override void Initialize()
        {
            MainVolumeSlider.value = _audioService.MainSoundVolume;
            EffectsVolumeSlider.value = _audioService.EffectsVolume;
            SoundsVolumeSlider.value = _audioService.SoundsVolume;
            
            base.Initialize();
            Id = WindowId.Settings;
        }

        protected override void SubscribeUpdates()
        {
            base.SubscribeUpdates();
            CloseButton.onClick.AddListener(Close);
            MainVolumeSlider.onValueChanged.AddListener(ChangeMainVolume);
            EffectsVolumeSlider.onValueChanged.AddListener(ChangeEffectsVolume);
            SoundsVolumeSlider.onValueChanged.AddListener(ChangeSoundsVolume);
        }

        private void ChangeMainVolume(float value)
        {
            _audioService.ChangeMainVolume(value);
        }

        private void ChangeEffectsVolume(float value)
        {
            _audioService.ChangeEffectsVolume(value);
        }

        private void ChangeSoundsVolume(float value)
        {
            _audioService.ChangeSoundsVolume(value);
        }

        protected override void UnsubscribeUpdates()
        {
            base.UnsubscribeUpdates();
            CloseButton.onClick.RemoveListener(Close);
        }

        private void Close()
        {
            _audioService.PlayAudio(SoundType.UIClick);
            _audioService.SavePreferences();
            _windowService.Close(Id);
        }
    }
}
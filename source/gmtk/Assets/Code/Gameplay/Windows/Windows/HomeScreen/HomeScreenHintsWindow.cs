using Code.Gameplay.Sounds.Config;
using Code.Gameplay.Sounds.Service;
using Code.Gameplay.Windows.Base;
using Code.Gameplay.Windows.Service;
using UnityEngine.UI;
using Zenject;

namespace Code.Gameplay.Windows.Windows.HomeScreen
{
    public class HomeScreenHintsWindow : BaseWindow
    {
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
            base.Initialize();
            Id = WindowId.HomeScreenControlHints;
        }
        
        protected override void SubscribeUpdates()
        {
            base.SubscribeUpdates();
            CloseButton.onClick.AddListener(Close);
        }

        protected override void UnsubscribeUpdates()
        {
            base.UnsubscribeUpdates();
            CloseButton.onClick.RemoveListener(Close);
        }

        private void Close()
        {
            _audioService.PlayAudio(SoundType.UIClick);
            _windowService.Close(Id);
        }
    }
}
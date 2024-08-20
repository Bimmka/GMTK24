using Code.Gameplay.Sounds.Config;
using Code.Gameplay.Sounds.Service;
using Code.Gameplay.Windows.Base;
using Code.Gameplay.Windows.Service;
using UnityEngine.UI;
using Zenject;

namespace Code.Gameplay.Windows.Windows.HomeScreen
{
    public class HomeScreenMenu : BaseWindow
    {
        public Button PlayButton;
        
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
            Id = WindowId.HomeScreenMenu;
        }

        protected override void SubscribeUpdates()
        {
            base.SubscribeUpdates();
            PlayButton.onClick.AddListener(OpenLevelsWindow);
        }

        protected override void UnsubscribeUpdates()
        {
            base.UnsubscribeUpdates();
            PlayButton.onClick.RemoveListener(OpenLevelsWindow);
        }

        private void OpenLevelsWindow()
        {
            _audioService.PlayAudio(SoundType.UIClick);
            _windowService.Open(WindowId.GameLevels);
            _windowService.Close(Id);
        }
    }
}
using Code.Gameplay.Windows.Base;
using Code.Gameplay.Windows.Service;
using UnityEngine.UI;
using Zenject;

namespace Code.Gameplay.Windows.Windows.HomeScreen
{
    public class HomeScreenMenu : BaseWindow
    {
        public Button PlayButton;
        public Button SettingsButton;
        
        private IWindowService _windowService;

        [Inject]
        private void Construct(IWindowService windowService)
        {
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
            SettingsButton.onClick.AddListener(OpenSettingsWindow);
        }

        protected override void UnsubscribeUpdates()
        {
            base.UnsubscribeUpdates();
            PlayButton.onClick.RemoveListener(OpenLevelsWindow);
            SettingsButton.onClick.RemoveListener(OpenSettingsWindow);
        }

        private void OpenLevelsWindow()
        {
            _windowService.Open(WindowId.GameLevels);
        }

        private void OpenSettingsWindow()
        {
            _windowService.Open(WindowId.Settings);
        }
    }
}
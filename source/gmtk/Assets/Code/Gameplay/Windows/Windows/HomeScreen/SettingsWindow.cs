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

        public Button CloseButton;
        
        private IWindowService _windowService;

        [Inject]
        private void Construct(IWindowService windowService)
        {
            _windowService = windowService;
        }
        
        protected override void Initialize()
        {
            base.Initialize();
            Id = WindowId.Settings;
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
            _windowService.Close(Id);
        }
    }
}
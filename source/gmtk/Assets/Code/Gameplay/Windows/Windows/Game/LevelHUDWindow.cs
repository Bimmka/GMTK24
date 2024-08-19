using Code.Gameplay.Levels;
using Code.Gameplay.StaticData;
using Code.Gameplay.Windows.Base;
using Code.Gameplay.Windows.Service;
using UnityEngine.UI;
using Zenject;

namespace Code.Gameplay.Windows.Windows.Game
{
    public class LevelHUDWindow : BaseWindow
    {
        public Button MenuButton;
        
        private ILevelDataProvider _levelDataProvider;
        private IStaticDataService _staticDataService;
        private IWindowService _windowService;

        [Inject]
        private void Construct(
            IWindowService windowService,
            IStaticDataService staticDataService,
            ILevelDataProvider levelDataProvider)
        {
            _levelDataProvider = levelDataProvider;
            _staticDataService = staticDataService;
            _windowService = windowService;
        }
        
        protected override void Initialize()
        {
            base.Initialize();
            Id = WindowId.LevelHUD;
        }
        
        protected override void SubscribeUpdates()
        {
            base.SubscribeUpdates();
            MenuButton.onClick.AddListener(OpenPauseMenu);
        }

        protected override void UnsubscribeUpdates()
        {
            base.UnsubscribeUpdates();
            MenuButton.onClick.RemoveListener(OpenPauseMenu);
        }

        private void OpenPauseMenu()
        {
            _windowService.Open(WindowId.PauseMenu);
        }
    }
}
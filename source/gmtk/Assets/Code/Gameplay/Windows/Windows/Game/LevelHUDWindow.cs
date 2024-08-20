using Code.Gameplay.Levels;
using Code.Gameplay.Sounds.Config;
using Code.Gameplay.Sounds.Service;
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
        public GameTaskStatusPanel TaskStatusPanel;
        public GameTaskInfoPanel TaskInfoPanel;
        
        private ILevelDataProvider _levelDataProvider;
        private IWindowService _windowService;
        private IAudioService _audioService;

        [Inject]
        private void Construct(
            IWindowService windowService,
            ILevelDataProvider levelDataProvider,
            IAudioService audioService)
        {
            _audioService = audioService;
            _levelDataProvider = levelDataProvider;
            _windowService = windowService;
        }
        
        protected override void Initialize()
        {
            base.Initialize();
            Id = WindowId.LevelHUD;

            TaskStatusPanel.Initialize();
            TaskInfoPanel.SetData(_levelDataProvider.CurrentId);
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
            _audioService.PlayAudio(SoundType.UIClick);
            _windowService.Open(WindowId.PauseMenu);
        }
    }
}
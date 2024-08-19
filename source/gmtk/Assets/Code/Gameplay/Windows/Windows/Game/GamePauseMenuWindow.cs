using Code.Gameplay.Common.Time;
using Code.Gameplay.Levels;
using Code.Gameplay.StaticData;
using Code.Gameplay.Windows.Base;
using Code.Gameplay.Windows.Service;
using Code.Infrastructure.Loading;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using UnityEngine.UI;
using Zenject;

namespace Code.Gameplay.Windows.Windows.Game
{
    public class GamePauseMenuWindow : BaseWindow
    {
        public Button CloseButton;
        public Button RestartLevelButton;
        public Button SettingsButton;

        public string LevelId;

        private ILevelDataProvider _levelDataProvider;
        private IGameStateMachine _gameStateMachine;
        private IStaticDataService _staticDataService;
        private IWindowService _windowService;
        private ITimeService _timeService;

        [Inject]
        private void Construct(
            IWindowService windowService,
            IStaticDataService staticDataService,
            IGameStateMachine gameStateMachine,
            ILevelDataProvider levelDataProvider,
            ITimeService timeService)
        {
            _timeService = timeService;
            _levelDataProvider = levelDataProvider;
            _gameStateMachine = gameStateMachine;
            _staticDataService = staticDataService;
            _windowService = windowService;
        }
        
        protected override void Initialize()
        {
            base.Initialize();
            Id = WindowId.PauseMenu;

            LevelId = _levelDataProvider.CurrentId;
            
            _timeService.StopTime();
        }
        
        protected override void SubscribeUpdates()
        {
            base.SubscribeUpdates();
            CloseButton.onClick.AddListener(Close);
            RestartLevelButton.onClick.AddListener(RestartLevel);
            SettingsButton.onClick.AddListener(OpenSettings);
        }

        protected override void UnsubscribeUpdates()
        {
            base.UnsubscribeUpdates();
            CloseButton.onClick.RemoveListener(Close);
            RestartLevelButton.onClick.RemoveListener(RestartLevel);
            SettingsButton.onClick.RemoveListener(OpenSettings);
        }
        
        private void Close()
        {
            _windowService.Close(Id);
            _timeService.StartTime();
        }

        private void RestartLevel()
        {
            _levelDataProvider.SetCurrentId(LevelId);
            _gameStateMachine.Enter<LoadingHomeScreenState>();
        }

        private void OpenSettings()
        {
            _windowService.Open(WindowId.Settings);
        }
    }
}
using Code.Gameplay.Features.Level.Config;
using Code.Gameplay.Levels;
using Code.Gameplay.StaticData;
using Code.Gameplay.Windows.Base;
using Code.Gameplay.Windows.Service;
using Code.Infrastructure.Loading;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using UnityEngine.UI;
using Zenject;

namespace Code.Gameplay.Windows.Windows.HomeScreen
{
    public class LevelInfoWindow : BaseWindow
    {
        public Button CloseButton;
        public Button StartLevelButton;
        public Button CompleteLevelButton;

        public string LevelId;

        private ILevelDataProvider _levelDataProvider;
        private IGameStateMachine _gameStateMachine;
        private IStaticDataService _staticDataService;
        private IWindowService _windowService;

        [Inject]
        private void Construct(
            IWindowService windowService,
            IStaticDataService staticDataService,
            IGameStateMachine gameStateMachine,
            ILevelDataProvider levelDataProvider)
        {
            _levelDataProvider = levelDataProvider;
            _gameStateMachine = gameStateMachine;
            _staticDataService = staticDataService;
            _windowService = windowService;
        }
        
        protected override void Initialize()
        {
            base.Initialize();
            Id = WindowId.LevelInfo;
        }
        
        protected override void SubscribeUpdates()
        {
            base.SubscribeUpdates();
            CloseButton.onClick.AddListener(Close);
            StartLevelButton.onClick.AddListener(StartLevel);
            CompleteLevelButton.onClick.AddListener(SkipLevel);
        }

        protected override void UnsubscribeUpdates()
        {
            base.UnsubscribeUpdates();
            CloseButton.onClick.RemoveListener(Close);
            StartLevelButton.onClick.RemoveListener(StartLevel);
            CompleteLevelButton.onClick.RemoveListener(SkipLevel);
        }

        public void SetData(string levelId, bool isCompleted)
        {
            LevelId = levelId;

            LevelConfig levelConfig = _staticDataService.GetLevelConfig(levelId);
        }

        private void Close()
        {
            _windowService.Close(Id);
        }

        private void StartLevel()
        {
            _levelDataProvider.SetCurrentId(LevelId);
            _gameStateMachine.Enter<LoadingBattleState, string>(Scenes.GameScene);
        }

        private void SkipLevel()
        {
            
        }
    }
}
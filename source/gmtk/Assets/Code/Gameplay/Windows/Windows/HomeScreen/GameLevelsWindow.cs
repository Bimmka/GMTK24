using System.Collections.Generic;
using Code.Gameplay.Features.Level.Config;
using Code.Gameplay.Levels;
using Code.Gameplay.Sounds.Config;
using Code.Gameplay.Sounds.Service;
using Code.Gameplay.StaticData;
using Code.Gameplay.Windows.Base;
using Code.Gameplay.Windows.Service;
using Code.Gameplay.Windows.Windows.HomeScreen.Factory;
using Code.Infrastructure.States.StateMachine;
using Code.Progress.Provider;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Gameplay.Windows.Windows.HomeScreen
{
    public class GameLevelsWindow : BaseWindow
    {
        public Button CloseButton;
        public Button SettingsButton;
        public Button ControlHintsButton;

        public RectTransform GameLevelsParent;
        
        private IWindowService _windowService;
        private IStaticDataService _staticDataService;
        private IProgressProvider _progressProvider;
        private IUIGameLevelViewFactory _factory;
        private IAudioService _audioService;

        [Inject]
        private void Construct(
            IWindowService windowService,
            IStaticDataService staticDataService,
            IProgressProvider progressProvider,
            IUIGameLevelViewFactory factory,
            IGameStateMachine gameStateMachine,
            ILevelDataProvider levelDataProvider,
            IAudioService audioService)
        {
            _audioService = audioService;
            _factory = factory;
            _progressProvider = progressProvider;
            _staticDataService = staticDataService;
            _windowService = windowService;
        }
        
        protected override void Initialize()
        {
            base.Initialize();
            Id = WindowId.GameLevels;
            SpawnGameLevels();
        }

        protected override void SubscribeUpdates()
        {
            base.SubscribeUpdates();
            CloseButton.onClick.AddListener(Close);
            SettingsButton.onClick.AddListener(OpenSettingsWindow);
            ControlHintsButton.onClick.AddListener(OpenControlHints);
        }

        protected override void UnsubscribeUpdates()
        {
            base.UnsubscribeUpdates();
            CloseButton.onClick.RemoveListener(Close);
            SettingsButton.onClick.RemoveListener(OpenSettingsWindow);
            ControlHintsButton.onClick.RemoveListener(OpenControlHints);
        }

        private void SpawnGameLevels()
        {
            List<LevelConfig> configs = _staticDataService.GetLevelConfigs();

            int index = 0;
            bool isPreviousPassed = false;
            foreach (LevelConfig levelConfig in configs)
            {
                GameLevelView gameLevelView = _factory.Create(GameLevelsParent);
                bool isLevelPassed = _progressProvider.ProgressData.PassedLevels.Contains(levelConfig.Id);
                gameLevelView.Initialize(index, levelConfig.Id, isLevelPassed, index == 0 || isPreviousPassed, OnLevelClick);
                index++;
                isPreviousPassed = isLevelPassed;
            }
        }

        private void OnLevelClick(string levelId, bool isCompleted)
        {
            LevelInfoWindow window = (LevelInfoWindow)_windowService.Open(WindowId.LevelInfo);
            window.SetData(levelId, isCompleted);
            _audioService.PlayAudio(SoundType.UIClick);
        }

        private void Close()
        {
            _audioService.PlayAudio(SoundType.UIClick);
            _windowService.Close(Id);
        }

        private void OpenSettingsWindow()
        {
            _audioService.PlayAudio(SoundType.UIClick);
            _windowService.Open(WindowId.Settings);
        }

        private void OpenControlHints()
        {
            _audioService.PlayAudio(SoundType.UIClick);
            _windowService.Open(WindowId.HomeScreenControlHints);
        }
    }
}
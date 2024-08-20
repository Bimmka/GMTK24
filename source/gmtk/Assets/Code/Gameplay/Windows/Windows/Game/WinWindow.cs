using Code.Gameplay.Common.Time;
using Code.Gameplay.Sounds.Config;
using Code.Gameplay.Sounds.Service;
using Code.Gameplay.Windows.Base;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using UnityEngine.UI;
using Zenject;

namespace Code.Gameplay.Windows.Windows.Game
{
    public class WinWindow : BaseWindow
    {
        public Button CloseButton;
        public Button RestartLevelButton;
        
        private ITimeService _timeService;
        private IGameStateMachine _gameStateMachine;
        private IAudioService _audioService;

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine, ITimeService timeService, IAudioService audioService)
        {
            _audioService = audioService;
            _gameStateMachine = gameStateMachine;
            _timeService = timeService;
        }
        
        protected override void Initialize()
        {
            base.Initialize();
            Id = WindowId.Win;
            
            _timeService.StopTime();
            _audioService.PlayAudio(SoundType.Win);
        }
        
        protected override void SubscribeUpdates()
        {
            base.SubscribeUpdates();
            CloseButton.onClick.AddListener(GoToMenu);
            RestartLevelButton.onClick.AddListener(GoToMenu);
        }

        protected override void UnsubscribeUpdates()
        {
            base.UnsubscribeUpdates();
            CloseButton.onClick.RemoveListener(GoToMenu);
            RestartLevelButton.onClick.RemoveListener(GoToMenu);

            _timeService.StartTime();
        }
        
        private void GoToMenu()
        {
            _audioService.PlayAudio(SoundType.UIClick);
            _gameStateMachine.Enter<LoadingHomeScreenState>();
        }
    }
}
using Code.Gameplay.Common.Time;
using Code.Gameplay.Sounds.Config;
using Code.Gameplay.Sounds.Service;
using Code.Gameplay.Windows.Base;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Gameplay.Windows.Windows.Game
{
    public class WinWindow : BaseWindow
    {
        public Transform AnimationContent;
        public float ScaleInDuration = 1f;
        public float ScaleOutDuration = 0.5f;
        public float DelayBeforeStart = 0.5f;
        
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
            AnimationContent.localScale = Vector3.zero;
            Sequence sequence = DOTween.Sequence();

            sequence.SetDelay(DelayBeforeStart)
                .Append(AnimationContent.DOScale(Vector3.one, ScaleInDuration).SetEase(Ease.InOutSine));

            sequence.Play();
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
            
            AnimationContent.DOScale(Vector3.zero, ScaleOutDuration).SetEase(Ease.InOutSine);
        }
    }
}
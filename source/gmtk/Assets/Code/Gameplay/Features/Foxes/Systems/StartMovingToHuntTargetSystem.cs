using System.Collections.Generic;
using Code.Gameplay.Sounds.Config;
using Code.Gameplay.Sounds.Service;
using Entitas;

namespace Code.Gameplay.Features.Foxes.Systems
{
    public class StartMovingToHuntTargetSystem : IExecuteSystem
    {
        private readonly IAudioService _audioService;
        private readonly IGroup<GameEntity> _foxes;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public StartMovingToHuntTargetSystem(GameContext game, IAudioService audioService)
        {
            _audioService = audioService;
            _foxes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fox,
                    GameMatcher.Hungry,
                    GameMatcher.Alive,
                    GameMatcher.HuntTarget,
                    GameMatcher.HuntStarted,
                    GameMatcher.ValidHuntTarget,
                    GameMatcher.MovementAvailable,
                    GameMatcher.FoxAnimator)
                .NoneOf(GameMatcher.MovingToHuntTarget));
        }

        public void Execute()
        {
            foreach (GameEntity fox in _foxes.GetEntities(_buffer))
            {
                fox.isMovingToHuntTarget = true;
                fox.isMoving = true;
                fox.isWaitingHunt = false;
                
                fox.FoxAnimator.PlayHunt();

                fox.ReplaceAttachedSound(_audioService.PlayAudio(SoundType.FoxGoToHuntTarget));
            }
        }
    }
}
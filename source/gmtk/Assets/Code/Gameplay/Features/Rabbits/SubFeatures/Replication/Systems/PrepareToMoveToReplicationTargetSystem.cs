using System.Collections.Generic;
using Code.Gameplay.Sounds.Config;
using Code.Gameplay.Sounds.Service;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Replication.Systems
{
    public class PrepareToMoveToReplicationTargetSystem : IExecuteSystem
    {
        private readonly IAudioService _audioService;
        private readonly IGroup<GameEntity> _rabbits;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public PrepareToMoveToReplicationTargetSystem(GameContext game, IAudioService audioService)
        {
            _audioService = audioService;
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Alive,
                    GameMatcher.WantToReplicate,
                    GameMatcher.Rabbit,
                    GameMatcher.ReplicationAvailable,
                    GameMatcher.RabbitAnimator,
                    GameMatcher.RabbitVisualChanger,
                    GameMatcher.WaitReplicationTimeLeft,
                    GameMatcher.WaitReplicationDuration,
                    GameMatcher.ValidReplicationTarget,
                    GameMatcher.MovementAvailable).
                NoneOf(GameMatcher.MovingToReplicationTarget));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits.GetEntities(_buffer))
            {
                rabbit.RabbitAnimator.PlayMoveToReplication();

                rabbit.RabbitVisualChanger.SetLove();
                
                rabbit.isWaitingForMoving = false;
                rabbit.isMovingUp = false;
                rabbit.isMoving = true;

                rabbit.isWaitingForNextReplicationUp = false;

                rabbit.isMovingToReplicationTarget = true;

                rabbit.ReplaceWaitReplicationTimeLeft(rabbit.WaitReplicationDuration);

                _audioService.PlayAudio(SoundType.GoToReplication);
            }
        }
    }
}
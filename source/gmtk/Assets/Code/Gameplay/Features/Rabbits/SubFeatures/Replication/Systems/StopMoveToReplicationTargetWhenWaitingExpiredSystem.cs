using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Replication.Systems
{
    public class StopMoveToReplicationTargetWhenWaitingExpiredSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _rabbits;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public StopMoveToReplicationTargetWhenWaitingExpiredSystem(GameContext game)
        {
            _game = game;
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ReplicationTarget,
                    GameMatcher.ReplicationExpired,
                    GameMatcher.ReplicationAvailable,
                    GameMatcher.ValidReplicationTarget,
                    GameMatcher.Alive,
                    GameMatcher.Rabbit,
                    GameMatcher.WantToReplicate,
                    GameMatcher.TimeLeftForNextReplication,
                    GameMatcher.ReplicationInterval,
                    GameMatcher.WaitReplicationTimeLeft,
                    GameMatcher.WaitReplicationDuration,
                    GameMatcher.RabbitVisualChanger,
                    GameMatcher.MovingToReplicationTarget));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits.GetEntities(_buffer))
            {
                rabbit.isValidReplicationTarget = false;
                
                rabbit.isCanBeChosenForReplication = true;
                rabbit.isWaitingForNextReplicationUp = true;
                rabbit.isCanStartReplication = true;
                rabbit.isWantToReplicate = false;
                rabbit.isMovingToReplicationTarget = false;
                
                rabbit.RabbitVisualChanger.RemoveLove();
                
                rabbit.ReplaceTimeLeftForNextReplication(rabbit.ReplicationInterval);
                rabbit.ReplaceWaitReplicationTimeLeft(rabbit.WaitReplicationDuration);

                GameEntity target = _game.GetEntityWithId(rabbit.ReplicationTarget);
                target.isValidReplicationTarget = false;
                target.isInvalidReplicationTarget = true;
                
                rabbit.RemoveReplicationTarget();
            }
        }
    }
}
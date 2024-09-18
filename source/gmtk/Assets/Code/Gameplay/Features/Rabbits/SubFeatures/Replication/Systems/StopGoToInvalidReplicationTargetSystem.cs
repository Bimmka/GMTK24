using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Replication.Systems
{
    public class StopGoToInvalidReplicationTargetSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _replicators;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public StopGoToInvalidReplicationTargetSystem(GameContext game)
        {
            _replicators = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.InvalidReplicationTarget,
                    GameMatcher.ReplicationTarget,
                    GameMatcher.WantToReplicate,
                    GameMatcher.RabbitVisualChanger,
                    GameMatcher.MoveDirection,
                    GameMatcher.MovingToReplicationTarget));
        }

        public void Execute()
        {
            foreach (GameEntity replicator in _replicators.GetEntities(_buffer))
            {
                replicator.isMovingToReplicationTarget = false;
                replicator.isWantToReplicate = false;
                replicator.RemoveMoveDirection();
                replicator.isMoving = false;
                
                replicator.RabbitVisualChanger.RemoveLove();
            }
        }
    }
}
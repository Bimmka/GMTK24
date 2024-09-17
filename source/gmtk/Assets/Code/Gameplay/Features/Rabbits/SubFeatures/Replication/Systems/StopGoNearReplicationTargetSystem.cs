using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Replication.Systems
{
    public class StopGoNearReplicationTargetSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _replicators;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public StopGoNearReplicationTargetSystem(GameContext game)
        {
            _replicators = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.ValidReplicationTarget,
                    GameMatcher.ReplicationTarget,
                    GameMatcher.NearReplicationTarget,
                    GameMatcher.ReplicationAvailable,
                    GameMatcher.WantToReplicate,
                    GameMatcher.MovingToReplicationTarget,
                    GameMatcher.Alive,
                    GameMatcher.MoveDirection));
        }

        public void Execute()
        {
            foreach (GameEntity replicator in _replicators.GetEntities(_buffer))
            {
                replicator.RemoveMoveDirection();
                replicator.isMoving = false;
            }
        }
    }
}
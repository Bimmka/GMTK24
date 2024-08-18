using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Replication.Systems
{
    public class ValidateReplicationNonDraggingTargetSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _targets;
        private readonly IGroup<GameEntity> _replicators;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public ValidateReplicationNonDraggingTargetSystem(GameContext game)
        {
            _targets = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ChosenForReplicationBy,
                    GameMatcher.ChosenForReplication,
                    GameMatcher.Rabbit,
                    GameMatcher.Id)
                .AnyOf(
                    GameMatcher.IdleState,
                    GameMatcher.StupidMoveState)
                .NoneOf(GameMatcher.DraggingState));
            
            _replicators = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ReplicationTarget,
                    GameMatcher.Rabbit,
                    GameMatcher.Id));
        }

        public void Execute()
        {
            foreach (GameEntity target in _targets.GetEntities(_buffer))
            {
                bool hasReplicator = false;
                foreach (GameEntity replicator in _replicators)
                {
                    if (replicator.ReplicationTarget == target.Id)
                    {
                        hasReplicator = true;
                        break;
                    }
                }

                if (hasReplicator == false)
                {
                    target.isChosenForReplication = false;
                    target.isCanBeChosenForReplication = true;
                    target.isWaitingForNextReplicationUp = true;
                    target.isCanStartReplication = true;
                    target.isReplicationTimeUp = false;
                    target.RemoveChosenForReplicationBy();
                }
            }
        }
    }
}
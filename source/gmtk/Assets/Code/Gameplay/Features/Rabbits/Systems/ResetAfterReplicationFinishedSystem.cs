using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.Systems
{
    public class ResetAfterReplicationFinishedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public ResetAfterReplicationFinishedSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.ReplicationFinished,
                    GameMatcher.TimeLeftForNextReplication,
                    GameMatcher.ReplicationInterval));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits.GetEntities(_buffer))
            {
                rabbit.isMovementAvailable = true;
                rabbit.isWaitingForMoving = true;
                rabbit.isWaitingForNextReplicationUp = true;
                rabbit.isChosenForReplication = false;
                rabbit.isReplicating = false;
                rabbit.isReplicationFinished = false;
                rabbit.isCanBeChosenForReplication = true;
                rabbit.isNearReplicationTarget = false;
                
                rabbit.isReplicationPhase = false;
                rabbit.isMovingPhase = true;

                if (rabbit.hasReplicationTarget)
                    rabbit.RemoveReplicationTarget();

                if (rabbit.hasChosenForReplicationBy)
                    rabbit.RemoveChosenForReplicationBy();

                rabbit.ReplaceTimeLeftForNextReplication(rabbit.ReplicationInterval);
            }
        }
    }
}
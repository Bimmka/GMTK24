using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Replication.Systems
{
    public class StopReplicationSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public StopReplicationSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.ReplicationFinished,
                    GameMatcher.TimeLeftForNextReplication,
                    GameMatcher.ReplicationInterval,
                    GameMatcher.WaitReplicationTimeLeft,
                    GameMatcher.WaitReplicationDuration,
                    GameMatcher.RabbitVisualChanger));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits.GetEntities(_buffer))
            {
                rabbit.isChosenForReplication = false;
                rabbit.isReplicating = false;
                rabbit.isReplicationFinished = false;
                rabbit.isNearReplicationTarget = false;
                rabbit.isValidReplicationTarget = false;
                rabbit.isReplicationTimeUp = false;

                rabbit.ReplaceTimeLeftForNextReplication(rabbit.ReplicationInterval);
                rabbit.ReplaceWaitReplicationTimeLeft(rabbit.WaitReplicationDuration);
                
                rabbit.RabbitVisualChanger.RemoveLove();
                
                if (rabbit.hasReplicationTarget)
                    rabbit.RemoveReplicationTarget();

                if (rabbit.hasChosenForReplicationBy)
                    rabbit.RemoveChosenForReplicationBy();
            }
        }
    }
}
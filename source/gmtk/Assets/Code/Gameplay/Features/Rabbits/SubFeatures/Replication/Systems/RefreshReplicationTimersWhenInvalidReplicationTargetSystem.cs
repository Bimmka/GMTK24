using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Replication.Systems
{
    public class RefreshReplicationTimersWhenInvalidReplicationTargetSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _replicators;

        public RefreshReplicationTimersWhenInvalidReplicationTargetSystem(GameContext game)
        {
            _replicators = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.InvalidReplicationTarget,
                    GameMatcher.ReplicationTarget,
                    GameMatcher.TimeLeftForNextReplication,
                    GameMatcher.ReplicationInterval,
                    GameMatcher.WaitReplicationTimeLeft,
                    GameMatcher.WaitReplicationDuration));
        }

        public void Execute()
        {
            foreach (GameEntity replicator in _replicators)
            {
                replicator.ReplaceTimeLeftForNextReplication(replicator.ReplicationInterval);
                replicator.ReplaceWaitReplicationTimeLeft(replicator.WaitReplicationDuration);
            }
        }
    }
}
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Replication.Systems
{
    public class MarkReplicationExpiredTimeSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;

        public MarkReplicationExpiredTimeSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.WantToReplicate,
                    GameMatcher.WaitReplicationTimeLeft,
                    GameMatcher.ReplicationAvailable,
                    GameMatcher.ValidReplicationTarget)
                .NoneOf(GameMatcher.Replicating));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                if (rabbit.WaitReplicationTimeLeft <= 0)
                    rabbit.isReplicationExpired = true;
            }
        }
    }
}
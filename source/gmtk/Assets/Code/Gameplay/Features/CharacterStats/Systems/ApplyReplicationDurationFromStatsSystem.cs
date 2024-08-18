using Code.Common.Extensions;
using Entitas;

namespace Code.Gameplay.Features.CharacterStats.Systems
{
    public class ApplyReplicationDurationFromStatsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statOwners;

        public ApplyReplicationDurationFromStatsSystem(GameContext game)
        {
            _statOwners = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.BaseStats,
                    GameMatcher.StatModifiers,
                    GameMatcher.DefaultReplicationDuration));
        }

        public void Execute()
        {
            foreach (GameEntity statOwner in _statOwners)
            {
                statOwner.ReplaceDefaultReplicationDuration(ReplicationDuration(statOwner).ZeroIfNegative());
            }
        }

        private static float ReplicationDuration(GameEntity statOwner)
        {
            return statOwner.BaseStats[Stats.ReplicationDuration] + statOwner.StatModifiers[Stats.ReplicationDuration];
        }
    }

    public class ApplyMaxIntervalBetweenReplicationsFromStatsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statOwners;

        public ApplyMaxIntervalBetweenReplicationsFromStatsSystem(GameContext game)
        {
            _statOwners = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.BaseStats,
                    GameMatcher.StatModifiers,
                    GameMatcher.MaxReplicationInterval,
                    GameMatcher.MinReplicationInterval));
        }

        public void Execute()
        {
            foreach (GameEntity statOwner in _statOwners)
            {
                float result = MaxReplicationInterval(statOwner).ZeroIfNegative();

                if (result < statOwner.MinReplicationInterval)
                    result = statOwner.MinReplicationInterval;
                
                statOwner.ReplaceDefaultReplicationDuration(result);
            }
        }

        private static float MaxReplicationInterval(GameEntity statOwner)
        {
            return statOwner.BaseStats[Stats.MaxIntervalBetweenReplications] + statOwner.StatModifiers[Stats.MaxIntervalBetweenReplications];
        }
    }
}
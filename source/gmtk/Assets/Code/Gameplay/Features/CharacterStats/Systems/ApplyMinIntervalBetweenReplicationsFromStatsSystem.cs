using Code.Common.Extensions;
using Entitas;

namespace Code.Gameplay.Features.CharacterStats.Systems
{
    public class ApplyMinIntervalBetweenReplicationsFromStatsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statOwners;

        public ApplyMinIntervalBetweenReplicationsFromStatsSystem(GameContext game)
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
                float result = MinReplicationInterval(statOwner).ZeroIfNegative();

                if (result > statOwner.MaxReplicationInterval)
                    result = statOwner.MaxReplicationInterval;
                
                statOwner.ReplaceDefaultReplicationDuration(result);
            }
        }

        private static float MinReplicationInterval(GameEntity statOwner)
        {
            return statOwner.BaseStats[Stats.MinIntervalBetweenReplications] + statOwner.StatModifiers[Stats.MinIntervalBetweenReplications];
        }
    }
}
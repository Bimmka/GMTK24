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
}
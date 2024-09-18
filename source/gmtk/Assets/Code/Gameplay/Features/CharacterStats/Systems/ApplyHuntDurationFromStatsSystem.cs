using Code.Common.Extensions;
using Entitas;

namespace Code.Gameplay.Features.CharacterStats.Systems
{
    public class ApplyHuntDurationFromStatsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statOwners;

        public ApplyHuntDurationFromStatsSystem(GameContext game)
        {
            _statOwners = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.BaseStats,
                    GameMatcher.StatModifiers,
                    GameMatcher.HuntDuration));
        }

        public void Execute()
        {
            foreach (GameEntity statOwner in _statOwners)
            {
                statOwner.ReplaceHuntDuration(HuntDuration(statOwner).ZeroIfNegative());
            }
        }

        private float HuntDuration(GameEntity statOwner)
        {
            return statOwner.BaseStats[Stats.HuntDuration] + statOwner.StatModifiers[Stats.HuntDuration];
        }
    }
}
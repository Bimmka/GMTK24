using Code.Common.Extensions;
using Entitas;

namespace Code.Gameplay.Features.CharacterStats.Systems
{
    public class ApplyBeforeNextHuntTimeFromStatsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statOwners;

        public ApplyBeforeNextHuntTimeFromStatsSystem(GameContext game)
        {
            _statOwners = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.BaseStats,
                    GameMatcher.StatModifiers,
                    GameMatcher.BeforeNextHuntInterval));
        }

        public void Execute()
        {
            foreach (GameEntity statOwner in _statOwners)
            {
                statOwner.ReplaceBeforeNextHuntInterval(BeforeNextHuntInterval(statOwner).ZeroIfNegative());
            }
        }

        private float BeforeNextHuntInterval(GameEntity statOwner)
        {
            return statOwner.BaseStats[Stats.BeforeNextHuntInterval] + statOwner.StatModifiers[Stats.BeforeNextHuntInterval];
        }
    }
}
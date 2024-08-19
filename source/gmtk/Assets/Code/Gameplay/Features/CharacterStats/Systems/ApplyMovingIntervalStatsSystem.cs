using Code.Common.Extensions;
using Entitas;

namespace Code.Gameplay.Features.CharacterStats.Systems
{
    public class ApplyMovingIntervalStatsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statOwners;

        public ApplyMovingIntervalStatsSystem(GameContext game)
        {
            _statOwners = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.BaseStats,
                    GameMatcher.StatModifiers,
                    GameMatcher.MovingInterval));
        }

        public void Execute()
        {
            foreach (GameEntity statOwner in _statOwners)
            {
                statOwner.ReplaceMovingInterval(MovingInterval(statOwner).ZeroIfNegative());
            }
        }

        private static float MovingInterval(GameEntity statOwner)
        {
            return statOwner.BaseStats[Stats.MovingInterval] + statOwner.StatModifiers[Stats.MovingInterval];
        }
    }
}
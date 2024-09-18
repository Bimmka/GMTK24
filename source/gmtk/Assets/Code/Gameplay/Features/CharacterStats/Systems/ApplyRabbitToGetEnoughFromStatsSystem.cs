using Code.Common.Extensions;
using Entitas;

namespace Code.Gameplay.Features.CharacterStats.Systems
{
    public class ApplyRabbitToGetEnoughFromStatsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statOwners;

        public ApplyRabbitToGetEnoughFromStatsSystem(GameContext game)
        {
            _statOwners = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.BaseStats,
                    GameMatcher.StatModifiers,
                    GameMatcher.TargetAmountToGetEnough));
        }

        public void Execute()
        {
            foreach (GameEntity statOwner in _statOwners)
            {
                statOwner.ReplaceTargetAmountToGetEnough(TargetAmountToGetEnough(statOwner).ZeroIfNegative());
            }
        }

        private int TargetAmountToGetEnough(GameEntity statOwner)
        {
            return (int)(statOwner.BaseStats[Stats.RabbitToGetEnough] + statOwner.StatModifiers[Stats.RabbitToGetEnough]);
        }
    }
}
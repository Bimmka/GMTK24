using Code.Common.Extensions;
using Entitas;

namespace Code.Gameplay.Features.CharacterStats.Systems
{
    public class ApplyDragReleaseDurationFromStatsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statOwners;

        public ApplyDragReleaseDurationFromStatsSystem(GameContext game)
        {
            _statOwners = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.BaseStats,
                    GameMatcher.StatModifiers,
                    GameMatcher.SelectionDragMaxTime));
        }

        public void Execute()
        {
            foreach (GameEntity statOwner in _statOwners)
            {
                statOwner.ReplaceSelectionDragMaxTime(DragReleaseDuration(statOwner).ZeroIfNegative());
            }
        }

        private static float DragReleaseDuration(GameEntity statOwner)
        {
            return statOwner.BaseStats[Stats.DragReleaseDuration] + statOwner.StatModifiers[Stats.DragReleaseDuration];
        }
    }
}
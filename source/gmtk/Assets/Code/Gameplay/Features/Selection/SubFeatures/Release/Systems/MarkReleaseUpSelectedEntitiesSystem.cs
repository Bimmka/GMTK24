using Entitas;

namespace Code.Gameplay.Features.Selection.SubFeatures.Release.Systems
{
    public class MarkReleaseUpSelectedEntitiesSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _selected;

        public MarkReleaseUpSelectedEntitiesSystem(GameContext game)
        {
            _selected = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Selected,
                    GameMatcher.SelectionDragTimeLeft,
                    GameMatcher.Dragging,
                    GameMatcher.DraggingState));
        }

        public void Execute()
        {
            foreach (GameEntity selected in _selected)
            {
                if (selected.SelectionDragTimeLeft <= 0)
                    selected.isReleaseFromDragUp = true;
            }
        }
    }
}
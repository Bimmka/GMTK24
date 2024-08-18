using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Selection.Systems
{
    public class RefreshDraggingMarkSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _selections;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(1);

        public RefreshDraggingMarkSystem(GameContext game)
        {
            _selections = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Selection,
                    GameMatcher.SelectedEntities,
                    GameMatcher.Dragging));
        }

        public void Execute()
        {
            foreach (GameEntity selection in _selections.GetEntities(_buffer))
            {
                selection.isDragging = selection.isHasSelections;
            }
        }
    }
}
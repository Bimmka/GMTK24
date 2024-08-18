using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Selection.SubFeatures.DragSelections.Systems
{
    public class CancelDraggingSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _selections;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(1);

        public CancelDraggingSystem(GameContext game)
        {
            _game = game;
            _selections = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.DragCanceled,
                    GameMatcher.SelectedEntities));
        }

        public void Execute()
        {
            foreach (GameEntity selection in _selections.GetEntities(_buffer))
            {
                foreach (int entityId in selection.SelectedEntities)
                {
                    GameEntity selectedEntity = _game.GetEntityWithId(entityId);

                    selectedEntity.isMovingToAfterDragPosition = true;
                    selectedEntity.isDragging = false;
                    selectedEntity.ReplaceAfterDragPosition(selectedEntity.SavedPositionBeforeDrag);
                }

                selection.isDragCanceled = false;
                selection.isUnselectSelectedEntities = true;
            }
        }
    }
}
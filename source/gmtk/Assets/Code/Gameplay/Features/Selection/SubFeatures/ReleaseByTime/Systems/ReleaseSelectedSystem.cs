using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.Selection.SubFeatures.ReleaseByTime
{
    public class ReleaseSelectedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _selected;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(16);

        public ReleaseSelectedSystem(GameContext game)
        {
            _selected = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Selected,
                    GameMatcher.ReleaseFromDragUp,
                    GameMatcher.SavedPositionBeforeDrag,
                    GameMatcher.Dragging,
                    GameMatcher.DraggingState));
        }

        public void Execute()
        {
            foreach (GameEntity selected in _selected.GetEntities(_buffer))
            {
                selected.isMovingToAfterDragPosition = true;
                selected.isDragging = false;
                selected.ReplaceAfterDragPosition(selected.SavedPositionBeforeDrag);
            }
        }
    }
}
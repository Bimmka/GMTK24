using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Selection.Systems
{
    public class SelectByMouseDraggingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _selections;
        private readonly IGroup<InputEntity> _inputs;
        private readonly IGroup<GameEntity> _selectables;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(1);

        public SelectByMouseDraggingSystem(GameContext game, InputContext input)
        {
            _selections = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Selection,
                    GameMatcher.WaitingMouseDragFinish));
            
            _inputs = input.GetGroup(InputMatcher
                .AllOf(
                    InputMatcher.Input,
                    InputMatcher.MouseUp,
                    InputMatcher.StartMouseDownWorldPosition,
                    InputMatcher.WorldMousePosition,
                    InputMatcher.WasDragging));

            _selectables = game.GetGroup(GameMatcher
                .AllOf(
                GameMatcher.Selectable,
                GameMatcher.WorldPosition,
                GameMatcher.Alive));
        }

        public void Execute()
        {
            foreach (InputEntity input in _inputs)
            {
                foreach (GameEntity selection in _selections.GetEntities(_buffer))
                {
                    Vector2 selectionAreaCenter = (input.StartMouseDownWorldPosition + input.WorldMousePosition) / 2;
                    Vector2 halfSelectionBounds = new Vector2(
                        Mathf.Abs(input.StartMouseDownWorldPosition.x - input.WorldMousePosition.x),
                        Mathf.Abs(input.StartMouseDownWorldPosition.y - input.WorldMousePosition.y)) / 2;
                    
                    foreach (GameEntity selectable in _selectables)
                    {
                        if (IsInSelectionArea(selectable, selectionAreaCenter, halfSelectionBounds))
                        {
                            selection.EntitiesForSelectionQueue.Enqueue(selectable.Id);
                        }
                    }

                    selection.isUnselectSelectedEntities = true;

                    selection.isWaitingMouseDragFinish = false;
                }
            }
        }

        private static bool IsInSelectionArea(GameEntity selectable, Vector2 selectionAreaCenter, Vector2 halfSelectionBounds)
        {
            return selectable.WorldPosition.x >= selectionAreaCenter.x - halfSelectionBounds.x
                   && selectable.WorldPosition.x <= selectionAreaCenter.x + halfSelectionBounds.x
                   && selectable.WorldPosition.y >= selectionAreaCenter.y - halfSelectionBounds.y
                   && selectable.WorldPosition.y <= selectionAreaCenter.y + halfSelectionBounds.y;
        }
    }
}
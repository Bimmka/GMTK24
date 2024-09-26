using System.Collections.Generic;
using Code.Gameplay.Features.Stalls.Services;
using Entitas;

namespace Code.Gameplay.Features.Selection.SubFeatures.DragSelections.Systems
{
    public class StopDragAfterConveyorBeltMouseClickSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<InputEntity> _clicks;
        private readonly IGroup<GameEntity> _selections;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(1);

        public StopDragAfterConveyorBeltMouseClickSystem(InputContext input, GameContext game)
        {
            _game = game;
            _clicks = input.GetGroup(InputMatcher
                .AllOf(
                    InputMatcher.Click,
                    InputMatcher.ConveyorBeltClicked,
                    InputMatcher.WorldMousePosition,
                    InputMatcher.ClickedEntityId));
            
            _selections = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.SelectedEntities,
                    GameMatcher.HasSelections,
                    GameMatcher.Dragging,
                    GameMatcher.SelectCenterRadius)
                .NoneOf(GameMatcher.DragStarted));
        }

        public void Execute()
        {
            foreach (InputEntity click in _clicks)
            {
                foreach (GameEntity selection in _selections.GetEntities(_buffer))
                {
                    selection.isDragging = false;
                    
                    foreach (int entityId in selection.SelectedEntities)
                    {
                        GameEntity selectedEntity = _game.GetEntityWithId(entityId);

                        selectedEntity.ReplaceAfterDragPosition(click.WorldMousePosition);
                        selectedEntity.isMovingToAfterDragPosition = true;
                        selectedEntity.isMovingToConveyorBeltAfterDrag = true;

                        selectedEntity.ReplaceParentConveyorBeltId(click.ClickedEntityId);
                    }

                    selection.isUnselectSelectedEntities = true;
                }
            }
        }
    }
}
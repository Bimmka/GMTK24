using System.Collections.Generic;
using Code.Gameplay.Features.Stalls.Services;
using Entitas;

namespace Code.Gameplay.Features.Selection.SubFeatures.DragSelections.Systems
{
    public class StopDragAfterMouseUpSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IStallService _stallService;
        private readonly IGroup<InputEntity> _inputs;
        private readonly IGroup<GameEntity> _selections;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(1);

        public StopDragAfterMouseUpSystem(InputContext input, GameContext game, IStallService stallService)
        {
            _game = game;
            _stallService = stallService;
            _inputs = input.GetGroup(InputMatcher
                .AllOf(
                    InputMatcher.Input,
                    InputMatcher.MouseUp,
                    InputMatcher.WorldMousePosition));
            
            _selections = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.SelectedEntities,
                    GameMatcher.HasSelections,
                    GameMatcher.Dragging,
                    GameMatcher.SelectCenterRadius));
        }

        public void Execute()
        {
            foreach (InputEntity input in _inputs)
            {
                foreach (GameEntity selection in _selections.GetEntities(_buffer))
                {
                    selection.isDragging = false;

                    int stallIndex = _stallService.GetStallIndex(input.WorldMousePosition);

                    if (stallIndex < 0)
                    {
                        selection.isDragCanceled = true;
                        continue;
                    }

                    foreach (int entityId in selection.SelectedEntities)
                    {
                        GameEntity selectedEntity = _game.GetEntityWithId(entityId);

                        if (selectedEntity.hasStallParentIndex)
                            selectedEntity.ReplaceStallParentIndex(stallIndex);

                        selectedEntity.ReplaceAfterDragPosition(_stallService.GetRandomPositionInStall(stallIndex, input.WorldMousePosition, selection.SelectCenterRadius));
                        selectedEntity.isMovingToAfterDragPosition = true;
                        selectedEntity.isDragging = false;
                    }
                    
                    selection.SelectedEntities.Clear();
                }
            }
        }
    }
}
using System.Collections.Generic;
using Code.Gameplay.Features.Stalls.Services;
using Entitas;

namespace Code.Gameplay.Features.Selection.SubFeatures.DragSelections.Systems
{
    public class StopDragAfterEmptyMouseClickSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IStallService _stallService;
        private readonly IGroup<InputEntity> _clicks;
        private readonly IGroup<GameEntity> _selections;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(1);

        public StopDragAfterEmptyMouseClickSystem(InputContext input, GameContext game, IStallService stallService)
        {
            _game = game;
            _stallService = stallService;
            _clicks = input.GetGroup(InputMatcher
                .AllOf(
                    InputMatcher.Click,
                    InputMatcher.EmptyClicked,
                    InputMatcher.WorldMousePosition));
            
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

                    int stallIndex = _stallService.GetStallIndex(click.WorldMousePosition);

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

                        selectedEntity.ReplaceAfterDragPosition(_stallService.GetRandomPositionInStall(stallIndex, click.WorldMousePosition, selection.SelectCenterRadius));
                        selectedEntity.isMovingToAfterDragPosition = true;
                    }

                    selection.isUnselectSelectedEntities = true;
                }
            }
        }
    }
}
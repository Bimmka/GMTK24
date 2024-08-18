using System.Collections.Generic;
using Code.Gameplay.Common.Random;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Selection.SubFeatures.DragSelections.Systems
{
    public class StartDragByMultipleSelectionSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IRandomService _randomService;
        private readonly IGroup<InputEntity> _inputs;
        private readonly IGroup<GameEntity> _selections;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(1);

        public StartDragByMultipleSelectionSystem(InputContext input, GameContext game, IRandomService randomService)
        {
            _game = game;
            _randomService = randomService;

            _inputs = input.GetGroup(InputMatcher
                .AllOf(
                    InputMatcher.Input,
                    InputMatcher.MouseUp,
                    InputMatcher.WasDragging));

            _selections = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.HasSelections)
                .NoneOf(GameMatcher.Dragging));
        }

        public void Execute()
        {
            foreach (InputEntity input in _inputs)
            {
                foreach (GameEntity selection in _selections.GetEntities(_buffer))
                {
                    foreach (int entityId in selection.SelectedEntities)
                    {
                        GameEntity selectedEntity = _game.GetEntityWithId(entityId);

                        selectedEntity.isDragging = true;
                        selectedEntity.isDragStarted = true;
                        selectedEntity.ReplaceSavedPositionBeforeDrag(selectedEntity.WorldPosition);

                        Vector2 randomPositionInUnitCircle = _randomService.InsideUnitCircle();
                        randomPositionInUnitCircle *= selection.SelectCenterRadius;
                        selectedEntity.ReplaceShiftFromSelect(randomPositionInUnitCircle);
                    }

                    selection.isDragging = true;
                    selection.isDragStarted = true;
                }
            }
        }
    }
}
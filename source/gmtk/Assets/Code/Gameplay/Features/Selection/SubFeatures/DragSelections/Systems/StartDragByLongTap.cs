using System.Collections.Generic;
using Code.Gameplay.Common.Physics;
using Code.Gameplay.Common.Random;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Selection.SubFeatures.DragSelections.Systems
{
    public class StartDragByLongTap : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IPhysicsService _physicsService;
        private readonly IRandomService _randomService;
        private readonly IGroup<InputEntity> _longTaps;
        private readonly IGroup<GameEntity> _selections;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(1);

        public StartDragByLongTap(InputContext input, GameContext game, IPhysicsService physicsService, IRandomService randomService)
        {
            _game = game;
            _physicsService = physicsService;
            _randomService = randomService;
            _longTaps = input.GetGroup(InputMatcher
                .AllOf(
                    InputMatcher.LongTap,
                    InputMatcher.WorldMousePosition));
            
            _selections = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.SelectedEntities,
                    GameMatcher.SelectionLayerMask,
                    GameMatcher.HasSelections)
                .NoneOf(GameMatcher.Dragging));
        }

        public void Execute()
        {
            foreach (InputEntity longTap in _longTaps)
            {
                foreach (GameEntity selection in _selections.GetEntities(_buffer))
                {
                    GameEntity result = _physicsService.Raycast(longTap.WorldMousePosition, Vector2.zero, selection.SelectionLayerMask);
                    
                    if (result == null)
                        continue;
                    
                    if (selection.SelectedEntities.Contains(result.Id) == false)
                        continue;

                    foreach (int entityId in selection.SelectedEntities)
                    {
                        GameEntity selectedEntity = _game.GetEntityWithId(entityId);

                        selectedEntity.isDragging = true;
                        selectedEntity.ReplaceSavedPositionBeforeDrag(selectedEntity.WorldPosition);

                        Vector2 randomPositionInUnitCircle = _randomService.InsideUnitCircle();
                        randomPositionInUnitCircle *= selection.SelectCenterRadius;
                        selectedEntity.ReplaceShiftFromSelect(randomPositionInUnitCircle);
                    }

                    selection.isDragging = true;
                }
            }
        }
    }
}
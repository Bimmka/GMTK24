using System.Collections.Generic;
using Code.Gameplay.Features.Stalls.Services;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Selection.SubFeatures.DragSelections.Systems
{
    public class SetPositionToSelectedEntitiesWhenCancelDraggingSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IStallService _stallService;
        private readonly IGroup<GameEntity> _selections;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(1);

        public SetPositionToSelectedEntitiesWhenCancelDraggingSystem(GameContext game, IStallService stallService)
        {
            _game = game;
            _stallService = stallService;
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
                    
                    if (selectedEntity == null)
                        continue;

                    if (_stallService.GetStallIndex(selectedEntity.SavedPositionBeforeDrag) >= 0)
                        continue;

                    int newStallIndex = _stallService.GetNearestStallIndexFromPosition(selectedEntity.SavedPositionBeforeDrag);
                    Vector3 newPosition = _stallService.GetRandomPositionInStall(newStallIndex);
                    selectedEntity.ReplaceSavedPositionBeforeDrag(newPosition);
                }
            }
        }
    }
}
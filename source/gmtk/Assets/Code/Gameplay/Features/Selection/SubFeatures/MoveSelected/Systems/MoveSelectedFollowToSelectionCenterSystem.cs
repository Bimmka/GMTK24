using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Selection.SubFeatures.MoveSelected.Systems
{
    public class MoveSelectedFollowToSelectionCenterSystem : IExecuteSystem
    {
        private const float DistanceError = 0.2f;

        private readonly GameContext _game;
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _selected;
        private readonly IGroup<GameEntity> _selectionCenters;

        public MoveSelectedFollowToSelectionCenterSystem(GameContext game, ITimeService time)
        {
            _game = game;
            _time = time;

            _selectionCenters = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.SelectCenterPosition,
                    GameMatcher.Dragging,
                    GameMatcher.FollowSelectCenterSpeed,
                    GameMatcher.HasSelections,
                    GameMatcher.SelectedEntities));
        }

        public void Execute()
        {
            foreach (GameEntity center in _selectionCenters)
            {
                foreach (int entityId in center.SelectedEntities)
                {
                    GameEntity selectedEntity = _game.GetEntityWithId(entityId);
                    
                    if (selectedEntity.isDead)
                        continue;
                    
                    Vector3 finishPosition = center.SelectCenterPosition + selectedEntity.ShiftFromSelect;
                    
                    if (Vector3.SqrMagnitude(finishPosition - selectedEntity.WorldPosition) < DistanceError)
                        continue;
                    
                    Vector3 direction = (finishPosition - selectedEntity.WorldPosition).normalized;

                    selectedEntity.ReplaceWorldPosition(selectedEntity.WorldPosition + direction * _time.DeltaTime * center.FollowSelectCenterSpeed);
                }
            }
        }
    }
}
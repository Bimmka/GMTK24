using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Selection.SubFeatures.MoveSelected.Systems
{
    public class MoveSelectedFollowToSelectionCenterSystem : IExecuteSystem
    {
        private const float DistanceError = 0.2f;
        
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _selected;
        private readonly IGroup<GameEntity> _selectionCenters;

        public MoveSelectedFollowToSelectionCenterSystem(GameContext game, ITimeService time)
        {
            _time = time;
            _selected = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Selected,
                    GameMatcher.Dragging,
                    GameMatcher.WorldPosition,
                    GameMatcher.ShiftFromSelect));

            _selectionCenters = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.SelectCenterPosition,
                    GameMatcher.Dragging,
                    GameMatcher.FollowSelectCenterSpeed));
        }

        public void Execute()
        {
            foreach (GameEntity center in _selectionCenters)
            {
                foreach (GameEntity selected in _selected)
                {
                    Vector3 finishPosition = center.SelectCenterPosition + selected.ShiftFromSelect;
                    
                    if (Vector3.SqrMagnitude(finishPosition - selected.WorldPosition) < DistanceError)
                        continue;
                    
                    Vector3 direction = (finishPosition - selected.WorldPosition).normalized;

                    selected.ReplaceWorldPosition(selected.WorldPosition + direction * _time.DeltaTime * center.FollowSelectCenterSpeed);
                }
            }
        }
    }
}
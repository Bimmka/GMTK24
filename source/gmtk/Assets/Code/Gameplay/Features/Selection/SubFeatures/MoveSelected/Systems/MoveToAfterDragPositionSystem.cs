using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Selection.SubFeatures.MoveSelected.Systems
{
    public class MoveToAfterDragPositionSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _selected;
        private readonly IGroup<GameEntity> _speeds;

        public MoveToAfterDragPositionSystem(GameContext game, ITimeService time)
        {
            _time = time;
            _selected = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.MovingToAfterDragPosition,
                    GameMatcher.AfterDragPosition,
                    GameMatcher.WorldPosition,
                    GameMatcher.Alive));

            _speeds = game.GetGroup(GameMatcher.MoveToAfterDragPositionSpeed);
        }

        public void Execute()
        {
            foreach (GameEntity selected in _selected)
            {
                foreach (GameEntity speed in _speeds)
                {
                    Vector3 direction = (selected.AfterDragPosition - selected.WorldPosition).normalized;
                    selected.ReplaceWorldPosition(selected.WorldPosition + direction * speed.MoveToAfterDragPositionSpeed * _time.DeltaTime);
                }
            }
        }
    }
}
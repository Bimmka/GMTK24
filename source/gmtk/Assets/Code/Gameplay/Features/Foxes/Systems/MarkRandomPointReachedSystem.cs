using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Foxes.Systems
{
    public class MarkRandomPointReachedSystem : IExecuteSystem
    {
        private const float DistanceError = 0.3f;
        private readonly IGroup<GameEntity> _foxes;

        public MarkRandomPointReachedSystem(GameContext game)
        {
            _foxes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fox,
                    GameMatcher.MovingToRandomPoint,
                    GameMatcher.Alive,
                    GameMatcher.WorldPosition,
                    GameMatcher.TargetPoint));
        }

        public void Execute()
        {
            foreach (GameEntity fox in _foxes)
            {
                if (Vector3.SqrMagnitude(fox.WorldPosition - fox.TargetPoint) <= DistanceError)
                    fox.isTargetPointReached = true;
            }
        }
    }
}
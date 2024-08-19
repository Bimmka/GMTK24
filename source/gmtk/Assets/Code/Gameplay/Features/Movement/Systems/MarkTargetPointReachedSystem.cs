using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class MarkTargetPointReachedSystem : IExecuteSystem
    {
        private const float DistanceError = 1.5f;

        private readonly IGroup<GameEntity> _movers;

        public MarkTargetPointReachedSystem(GameContext game)
        {
            _movers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TargetPoint,
                    GameMatcher.WorldPosition,
                    GameMatcher.MovementAvailable));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _movers)
            {
                if (Vector3.Distance(mover.TargetPoint, mover.WorldPosition) <= DistanceError)
                    mover.isTargetPointReached = true;
            }
        }
    }
}
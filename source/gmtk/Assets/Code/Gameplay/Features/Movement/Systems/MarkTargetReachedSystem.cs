using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class MarkTargetReachedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movers;

        public MarkTargetReachedSystem(GameContext game)
        {
            _movers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TargetPoint,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _movers)
            {
                if (Vector3.SqrMagnitude(mover.TargetPoint - mover.WorldPosition) <= 0.5f)
                    mover.isTargetReached = true;
            }
        }
    }
}
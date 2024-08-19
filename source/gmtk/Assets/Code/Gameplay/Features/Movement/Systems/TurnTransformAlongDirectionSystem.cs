using Code.Common.Extensions;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class TurnTransformAlongDirectionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movers;

        public TurnTransformAlongDirectionSystem(GameContext game)
        {
            _movers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TurnedAlongDirection,
                    GameMatcher.MoveDirection,
                    GameMatcher.RotationTransform));
        }
    
        public void Execute()
        {
            foreach (GameEntity mover in _movers)
            {
                float scale = Mathf.Abs(mover.RotationTransform.transform.localScale.x);
                mover.RotationTransform.transform.SetScaleX(scale * FaceDirection(mover));
            }
        }

        private float FaceDirection(GameEntity mover) =>
            mover.MoveDirection.x <= 0 
                ? 1 
                : -1;
    }
}
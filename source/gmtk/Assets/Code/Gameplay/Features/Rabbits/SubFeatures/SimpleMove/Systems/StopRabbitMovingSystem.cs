using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.SimpleMove.Systems
{
    public class StopRabbitMovingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public StopRabbitMovingSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Alive,
                    GameMatcher.Moving,
                    GameMatcher.TargetPoint,
                    GameMatcher.TargetPointReached,
                    GameMatcher.MoveDirection));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits.GetEntities(_buffer))
            {
                rabbit.isMoving = false;

                rabbit.isWaitingForMoving = true;

                rabbit.RemoveMoveDirection();

                if (rabbit.hasRabbitAnimator)
                    rabbit.RabbitAnimator.PlayIdle();
            }
        }
    }
}
using System.Collections.Generic;
using Code.Gameplay.Features.Stalls.Services;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.Systems
{
    public class StarMoveRabbitSystem : IExecuteSystem
    {
        private readonly IStallService _stallService;
        private readonly IGroup<GameEntity> _rabbits;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public StarMoveRabbitSystem(GameContext game, IStallService stallService)
        {
            _stallService = stallService;

            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.MovingUp,
                    GameMatcher.MovementAvailable,
                    GameMatcher.StallParentIndex,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits.GetEntities(_buffer))
            {
                rabbit.isMovingUp = false;
                rabbit.isWaitingForMoving = false;
                rabbit.isMoving = true;

                if (rabbit.hasRabbitAnimator)
                    rabbit.RabbitAnimator.PlayMoving();

                rabbit.AddTargetPoint(_stallService.GetRandomPositionInStall(rabbit.StallParentIndex));
                rabbit.ReplaceMoveDirection((rabbit.TargetPoint - rabbit.WorldPosition).normalized);
            }
        }
    }
}
using System.Collections.Generic;
using Code.Gameplay.Features.Stalls.Services;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.StupidMove.Systems
{
    public class StartRabbitMovingSystem : IExecuteSystem
    {
        private readonly IStallService _stallService;
        private readonly IGroup<GameEntity> _rabbits;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public StartRabbitMovingSystem(GameContext game, IStallService stallService)
        {
            _stallService = stallService;
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.Alive,
                    GameMatcher.MovingUp,
                    GameMatcher.WaitingForMoving,
                    GameMatcher.MovementAvailable,
                    GameMatcher.WorldPosition,
                    GameMatcher.StallParentIndex));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits.GetEntities(_buffer))
            {
                rabbit.isMoving = true;
                rabbit.isWaitingForMoving = false;

                rabbit.ReplaceTargetPoint(_stallService.GetRandomPositionInStall(rabbit.StallParentIndex));
                rabbit.ReplaceMoveDirection((rabbit.TargetPoint - rabbit.WorldPosition).normalized);

                if (rabbit.hasRabbitAnimator)
                    rabbit.RabbitAnimator.PlayMoving();
            }
        }
    }
}
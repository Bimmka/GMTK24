using Entitas;

namespace Code.Gameplay.Features.Rabbits.Systems
{
    public class StopMoveRabbitSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;

        public StopMoveRabbitSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.TargetReached));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                rabbit.isMoving = false;
                
                if (rabbit.hasRabbitAnimator)
                    rabbit.RabbitAnimator.PlayIdle();
            }
        }
    }
}
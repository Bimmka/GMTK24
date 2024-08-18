using Entitas;

namespace Code.Gameplay.Features.Rabbits.Systems
{
    public class UpdateMovingMarkSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;

        public UpdateMovingMarkSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Rabbit));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                rabbit.isMoving = rabbit.isMovementAvailable && (rabbit.hasTargetPoint || rabbit.hasReplicationTarget);
            }
        }
    }
}
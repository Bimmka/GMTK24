using Entitas;

namespace Code.Gameplay.Features.Rabbits.Systems
{
    public class RefreshTimeForMovingForReachedTargetRabbitSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;

        public RefreshTimeForMovingForReachedTargetRabbitSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.TargetReached,
                    GameMatcher.MovingInterval,
                    GameMatcher.TimeLeftForMoving));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                rabbit.ReplaceTimeLeftForMoving(rabbit.MovingInterval);
                rabbit.isWaitingForMoving = true;
            }
        }
    }
}
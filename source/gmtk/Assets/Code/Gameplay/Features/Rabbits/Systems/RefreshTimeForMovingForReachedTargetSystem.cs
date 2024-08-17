using Entitas;

namespace Code.Gameplay.Features.Rabbits.Systems
{
    public class RefreshTimeForMovingForReachedTargetSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;

        public RefreshTimeForMovingForReachedTargetSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.TargetPointReached,
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
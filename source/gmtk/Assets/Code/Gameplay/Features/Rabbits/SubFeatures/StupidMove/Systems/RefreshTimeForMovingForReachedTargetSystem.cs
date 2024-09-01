using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.StupidMove.Systems
{
    public class RefreshTimeForMovingForReachedTargetSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;

        public RefreshTimeForMovingForReachedTargetSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Alive,
                    GameMatcher.TargetPointReached,
                    GameMatcher.TimeLeftForMoving,
                    GameMatcher.MovingInterval));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                rabbit.ReplaceTimeLeftForMoving(rabbit.MovingInterval);
            }
        }
    }
}
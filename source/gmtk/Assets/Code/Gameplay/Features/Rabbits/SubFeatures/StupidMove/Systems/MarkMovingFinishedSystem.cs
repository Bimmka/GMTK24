using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.StupidMove.Systems
{
    public class MarkMovingFinishedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;

        public MarkMovingFinishedSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.TargetPointReached,
                    GameMatcher.StupidMoveState));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                rabbit.isMovingFinished = true;
            }
        }
    }
}
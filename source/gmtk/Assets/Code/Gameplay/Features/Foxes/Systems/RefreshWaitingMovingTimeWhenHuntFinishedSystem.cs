using Entitas;

namespace Code.Gameplay.Features.Foxes.Systems
{
    public class RefreshWaitingMovingTimeWhenHuntFinishedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _foxes;

        public RefreshWaitingMovingTimeWhenHuntFinishedSystem(GameContext game)
        {
            _foxes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fox,
                    GameMatcher.HuntFinished,
                    GameMatcher.MovingInterval,
                    GameMatcher.TimeLeftForMoving)
                .NoneOf(GameMatcher.MovingToRandomPoint));
        }

        public void Execute()
        {
            foreach (GameEntity fox in _foxes)
            {
                fox.ReplaceTimeLeftForMoving(fox.MovingInterval);
            }
        }
    }
}
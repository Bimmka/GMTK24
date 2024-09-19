using Entitas;

namespace Code.Gameplay.Features.Foxes.SubFeatures.Hunt.Systems
{
    public class MarkWaitingForMovingAfterHuntFinishedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _foxes;

        public MarkWaitingForMovingAfterHuntFinishedSystem(GameContext game)
        {
            _foxes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fox,
                    GameMatcher.Alive,
                    GameMatcher.HuntFinished)
                .NoneOf(GameMatcher.MovingToRandomPoint));
        }

        public void Execute()
        {
            foreach (GameEntity fox in _foxes)
            {
                fox.isWaitingForMoving = true;
                fox.isMoving = false;
            }
        }
    }
}
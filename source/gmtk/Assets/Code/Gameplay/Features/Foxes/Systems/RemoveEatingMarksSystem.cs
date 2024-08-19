using Entitas;

namespace Code.Gameplay.Features.Foxes.Systems
{
    public class RemoveEatingMarksSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _foxes;

        public RemoveEatingMarksSystem(GameContext game)
        {
            _foxes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fox,
                    GameMatcher.Alive));
        }

        public void Execute()
        {
            foreach (GameEntity fox in _foxes)
            {
                fox.isEatingFinished = false;
                fox.isEatingStarted = false;
                fox.isGotEnough = false;
            }
        }
    }
}
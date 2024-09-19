using Entitas;

namespace Code.Gameplay.Features.Foxes.SubFeatures.Hunt.Systems
{
    public class RefreshEatingTimeSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _foxes;

        public RefreshEatingTimeSystem(GameContext game)
        {
            _foxes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fox,
                    GameMatcher.EatingDuration,
                    GameMatcher.EatingTimeLeft,
                    GameMatcher.EatingFinished));
        }

        public void Execute()
        {
            foreach (GameEntity fox in _foxes)
            {
                fox.ReplaceEatingTimeLeft(fox.EatingDuration);
            }
        }
    }
}
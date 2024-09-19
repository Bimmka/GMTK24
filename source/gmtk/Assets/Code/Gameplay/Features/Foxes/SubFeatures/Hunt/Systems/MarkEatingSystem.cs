using Entitas;

namespace Code.Gameplay.Features.Foxes.SubFeatures.Hunt.Systems
{
    public class MarkEatingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _foxes;

        public MarkEatingSystem(GameContext game)
        {
            _foxes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fox,
                    GameMatcher.Hungry,
                    GameMatcher.Alive,
                    GameMatcher.ValidHuntTarget,
                    GameMatcher.NearHuntTarget,
                    GameMatcher.EatingStarted));
        }

        public void Execute()
        {
            foreach (GameEntity fox in _foxes)
            {
                fox.isEating = true;
            }
        }
    }
}

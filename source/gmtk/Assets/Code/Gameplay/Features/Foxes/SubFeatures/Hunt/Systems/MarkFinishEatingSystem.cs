using Entitas;

namespace Code.Gameplay.Features.Foxes.SubFeatures.Hunt.Systems
{
    public class MarkFinishEatingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _foxes;

        public MarkFinishEatingSystem(GameContext game)
        {
            _foxes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fox,
                    GameMatcher.Eating,
                    GameMatcher.Alive,
                    GameMatcher.EatingTimeLeft));
        }

        public void Execute()
        {
            foreach (GameEntity fox in _foxes)
            {
                if (fox.EatingTimeLeft <= 0)
                    fox.isEatingFinished = true;
            }
        }
    }
}
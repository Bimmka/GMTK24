using Entitas;

namespace Code.Gameplay.Features.Foxes.SubFeatures.Hunt.Systems
{
    public class MarkHungrySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _foxes;

        public MarkHungrySystem(GameContext game)
        {
            _foxes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fox,
                    GameMatcher.BeforeNextHuntTimeLeft,
                    GameMatcher.WaitingHunt,
                    GameMatcher.Alive));
        }

        public void Execute()
        {
            foreach (GameEntity fox in _foxes)
            {
                if (fox.BeforeNextHuntTimeLeft <= 0)
                    fox.isHungry = true;
            }
        }
    }
}
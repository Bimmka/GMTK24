using Entitas;

namespace Code.Gameplay.Features.Foxes.SubFeatures.Hunt.Systems
{
    public class MarkGotEnoughSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _foxes;

        public MarkGotEnoughSystem(GameContext game)
        {
            _foxes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fox,
                    GameMatcher.Hungry,
                    GameMatcher.Alive,
                    GameMatcher.TargetAmountToGetEnough,
                    GameMatcher.TargetAmountGot));
        }

        public void Execute()
        {
            foreach (GameEntity fox in _foxes)
            {
                if (fox.TargetAmountGot >= fox.TargetAmountToGetEnough)
                    fox.isGotEnough = true;
            }
        }
    }
}
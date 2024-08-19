using Entitas;

namespace Code.Gameplay.Features.Foxes.Systems
{
    public class MarkHuntFinishedWhenGotEnoughSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _foxes;

        public MarkHuntFinishedWhenGotEnoughSystem(GameContext game)
        {
            _foxes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fox,
                    GameMatcher.Hungry,
                    GameMatcher.Alive,
                    GameMatcher.GotEnough));
        }

        public void Execute()
        {
            foreach (GameEntity fox in _foxes)
            {
                fox.isHuntFinished = true;
            }
        }
    }
}
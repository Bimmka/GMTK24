using Entitas;

namespace Code.Gameplay.Features.Foxes.Systems
{
    public class MarkHuntStartedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _foxes;

        public MarkHuntStartedSystem(GameContext game)
        {
            _foxes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fox,
                    GameMatcher.Hungry,
                    GameMatcher.Alive,
                    GameMatcher.HuntTarget)
                .NoneOf(GameMatcher.MovingToHuntTarget));
        }

        public void Execute()
        {
            foreach (GameEntity fox in _foxes)
            {
                fox.isHuntStarted = true;
            }
        }
    }
}
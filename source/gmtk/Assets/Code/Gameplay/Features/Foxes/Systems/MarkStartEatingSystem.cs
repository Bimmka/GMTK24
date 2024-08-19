using Entitas;

namespace Code.Gameplay.Features.Foxes.Systems
{
    public class MarkStartEatingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _foxes;

        public MarkStartEatingSystem(GameContext game)
        {
            _foxes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fox,
                    GameMatcher.Hungry,
                    GameMatcher.Alive,
                    GameMatcher.HuntTarget,
                    GameMatcher.ValidHuntTarget,
                    GameMatcher.NearHuntTarget)
                .NoneOf(GameMatcher.Eating));
        }

        public void Execute()
        {
            foreach (GameEntity fox in _foxes)
            {
                fox.isEatingStarted = true;
            }
        }
    }
}
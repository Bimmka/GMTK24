using Entitas;

namespace Code.Gameplay.Features.Foxes.Systems
{
    public class RemoveMarkTargetPointReachedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _foxes;

        public RemoveMarkTargetPointReachedSystem(GameContext game)
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
                fox.isTargetPointReached = false;
            }
        }
    }
}
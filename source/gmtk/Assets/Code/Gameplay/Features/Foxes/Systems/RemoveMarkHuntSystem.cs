using Entitas;

namespace Code.Gameplay.Features.Foxes.Systems
{
    public class RemoveMarkHuntSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _foxes;

        public RemoveMarkHuntSystem(GameContext game)
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
                fox.isHuntStarted = false;
                fox.isHuntFinished = false;
            }
        }
    }
}
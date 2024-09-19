using Entitas;

namespace Code.Gameplay.Features.Foxes.SubFeatures.SimpleMove.Systems
{
    public class MarkMovingUpSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _foxes;

        public MarkMovingUpSystem(GameContext game)
        {
            _foxes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fox,
                    GameMatcher.WaitingForMoving,
                    GameMatcher.TimeLeftForMoving,
                    GameMatcher.Alive));
        }

        public void Execute()
        {
            foreach (GameEntity fox in _foxes)
            {
                if (fox.TimeLeftForMoving <= 0)
                    fox.isMovingUp = true;
            }
        }
    }
}
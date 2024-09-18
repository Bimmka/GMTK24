using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.States.Systems
{
    public class PrepareForDraggingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;

        public PrepareForDraggingSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.DragStarted,
                    GameMatcher.Alive));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                rabbit.isMoving = false;

                if (rabbit.hasMoveDirection)
                    rabbit.RemoveMoveDirection();
            }
        }
    }
}
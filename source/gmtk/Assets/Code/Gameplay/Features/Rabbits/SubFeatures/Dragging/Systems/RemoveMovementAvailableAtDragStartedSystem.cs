using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Dragging.Systems
{
    public class RemoveMovementAvailableAtDragStartedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;

        public RemoveMovementAvailableAtDragStartedSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.DragStarted));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                rabbit.isMovementAvailable = false;
            }
        }
    }
}
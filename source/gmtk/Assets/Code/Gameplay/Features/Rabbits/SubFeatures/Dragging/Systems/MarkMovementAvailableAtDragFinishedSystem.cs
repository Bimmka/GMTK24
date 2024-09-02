using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Dragging.Systems
{
    public class MarkMovementAvailableAtDragFinishedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;

        public MarkMovementAvailableAtDragFinishedSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.DragFinished));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                rabbit.isMovementAvailable = true;
            }
        }
    }
}
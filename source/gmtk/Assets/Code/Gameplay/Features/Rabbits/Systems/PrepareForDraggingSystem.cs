using Entitas;

namespace Code.Gameplay.Features.Rabbits.Systems
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
                    GameMatcher.SelectionDragMaxTime,
                    GameMatcher.SelectionDragTimeLeft));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                rabbit.isWaitingForMoving = false;
                rabbit.isWaitingForNextReplicationUp = false;
                rabbit.isMovementAvailable = false;
                rabbit.isCanBeChosenForReplication = false;
                rabbit.isSelectable = false;

                rabbit.isMovingPhase = false;
                rabbit.isReplicationPhase = false;
                rabbit.isDraggingPhase = true;

                rabbit.ReplaceSelectionDragTimeLeft(rabbit.SelectionDragMaxTime);
            }
        }
    }
}
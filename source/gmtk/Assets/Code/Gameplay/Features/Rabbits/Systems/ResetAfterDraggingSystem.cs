using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.Systems
{
    public class ResetAfterDraggingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public ResetAfterDraggingSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.DragFinished));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits.GetEntities(_buffer))
            {
                rabbit.isWaitingForMoving = true;
                rabbit.isWaitingForNextReplicationUp = true;
                rabbit.isMovementAvailable = true;
                rabbit.isCanBeChosenForReplication = true;
                rabbit.RemoveAfterDragPosition();
                rabbit.RemoveShiftFromSelect();
                rabbit.RemoveSavedPositionBeforeDrag();
                rabbit.isDragging = false;
                rabbit.isDragFinished = false;
                rabbit.isSelected = false;
                rabbit.isSelectable = true;
                
                rabbit.isDraggingPhase = false;
                rabbit.isMovingPhase = true;
            }
        }
    }
}
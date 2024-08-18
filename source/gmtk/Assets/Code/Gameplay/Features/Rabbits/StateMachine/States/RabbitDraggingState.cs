namespace Code.Gameplay.Features.Rabbits.StateMachine.States
{
    public class RabbitDraggingState : EntitySimpleState
    {
        public override void Enter()
        {
            base.Enter();
            
            Entity.ChangeStateToDragging();
            
            Entity.isWaitingForMoving = false;
            Entity.isWaitingForNextReplicationUp = false;
            Entity.isMovementAvailable = false;
            Entity.isCanBeChosenForReplication = false;
            Entity.isSelectable = false;
            
            Entity.ReplaceSelectionDragTimeLeft(Entity.SelectionDragMaxTime);
        }

        protected override void Exit()
        {
            base.Exit();
            
            Entity.isDragging = false;
            Entity.isDragFinished = false;
            Entity.isSelected = false;
            Entity.isSelectable = true;
            
            if (Entity.hasAfterDragPosition)
                Entity.RemoveAfterDragPosition();

            if (Entity.hasShiftFromSelect)
                Entity.RemoveShiftFromSelect();

            if (Entity.hasSavedPositionBeforeDrag)
                Entity.RemoveSavedPositionBeforeDrag();
        }
    }
}
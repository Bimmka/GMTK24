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

            Entity.isDragFinished = false;
            Entity.isDragStarted = false;

            Entity.isSelected = false;
            Entity.isSelectable = true;

            bool isChosenForReplicationBy = Entity.hasChosenForReplicationBy;
            if (isChosenForReplicationBy == false && Entity.isReplicationAvailable && Entity.isAlive)
            {
                Entity.isWaitingForNextReplicationUp = true;
                Entity.isCanBeChosenForReplication = true;
                Entity.isCanStartReplication = true;
            }

            if (Entity.hasAfterDragPosition)
                Entity.RemoveAfterDragPosition();

            if (Entity.hasShiftFromSelect)
                Entity.RemoveShiftFromSelect();

            if (Entity.hasSavedPositionBeforeDrag)
                Entity.RemoveSavedPositionBeforeDrag();
        }
    }
}
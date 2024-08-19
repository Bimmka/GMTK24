namespace Code.Gameplay.Features.Rabbits.StateMachine.States
{
    public class RabbitDeadState : EntitySimpleState
    {
        public override void Enter()
        {
            base.Enter();
            
            Entity.ChangeStateToDead();
            
            Entity.isMovingUp = false;
            Entity.isWaitingForMoving = false;
            Entity.isMoving = false;
            Entity.isMovementAvailable = false;
            Entity.isReplicationAvailable = false;
            Entity.isReplicationBlocked = true;
            Entity.isSelectable = false;

            if (Entity.hasRabbitAnimator)
                Entity.RabbitAnimator.PlayDead();
            
            if (Entity.hasRabbitVisualChanger)
                Entity.RabbitVisualChanger.ApplySelectionStatus(false);

            Entity.AddSelfDestructTimer(1f);
        }
    }
}
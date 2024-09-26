namespace Code.Gameplay.Features.Rabbits.StateMachine.States
{
    public class RabbitIdleState : EntitySimpleState
    {
        public override void Enter()
        {
            base.Enter();

            Entity.isMovementAvailable = true;
            Entity.isWaitingForMoving = true;

            if (Entity.isReplicationAvailable)
                Entity.isWaitingForNextReplicationUp = true;

            Entity.isSelectable = true;
            
            if (Entity.hasRabbitAnimator)
                Entity.RabbitAnimator.PlayIdle();
        }

        protected override void Exit()
        {
            base.Exit();
        }
    }
}
namespace Code.Gameplay.Features.Rabbits.StateMachine.States
{
    public class RabbitReplicationState : EntitySimpleState
    {
        public override void Enter()
        {
            base.Enter();
            
            Entity.ChangeStateToReplication();
            
            Entity.isWaitingForMoving = false;
            Entity.isMovingUp = false;
            Entity.isWaitingForNextReplicationUp = false;
        }

        protected override void Exit()
        {
            base.Exit();
            Entity.isChosenForReplication = false;
            Entity.isReplicating = false;
            Entity.isReplicationFinished = false;
            Entity.isNearReplicationTarget = false;
            Entity.isWantToReplicate = false;

            Entity.ReplaceTimeLeftForNextReplication(Entity.ReplicationInterval);
            
            if (Entity.hasReplicationTarget)
                Entity.RemoveReplicationTarget();

            if (Entity.hasChosenForReplicationBy)
                Entity.RemoveChosenForReplicationBy();
        }
    }
}
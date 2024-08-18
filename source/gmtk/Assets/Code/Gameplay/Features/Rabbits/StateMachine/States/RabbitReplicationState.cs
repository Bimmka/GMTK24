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
            Entity.isMoving = false;
            Entity.isWaitingForNextReplicationUp = false;
        }

        protected override void Exit()
        {
            base.Exit();
            Entity.isChosenForReplication = false;
            Entity.isReplicating = false;
            Entity.isReplicationFinished = false;
            Entity.isNearReplicationTarget = false;
            Entity.isCanBeChosenForReplication = true;
            Entity.isWaitingForNextReplicationUp = true;
            Entity.isCanStartReplication = true;
            Entity.isReplicationTimeUp = false;

            Entity.ReplaceTimeLeftForNextReplication(Entity.ReplicationInterval);
            
            if (Entity.hasReplicationTarget)
                Entity.RemoveReplicationTarget();

            if (Entity.hasChosenForReplicationBy)
                Entity.RemoveChosenForReplicationBy();
        }
    }
}
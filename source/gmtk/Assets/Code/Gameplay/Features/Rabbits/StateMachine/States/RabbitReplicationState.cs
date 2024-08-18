using Code.Gameplay.Common.Random;

namespace Code.Gameplay.Features.Rabbits.StateMachine.States
{
    public class RabbitReplicationState : EntitySimpleState
    {
        private readonly IRandomService _randomService;

        public RabbitReplicationState(IRandomService randomService)
        {
            _randomService = randomService;
        }
        
        public override void Enter()
        {
            base.Enter();
            
            Entity.ChangeStateToReplication();
            
            Entity.isWaitingForMoving = false;
            Entity.isMovingUp = false;
            Entity.isMoving = false;
            Entity.isWaitingForNextReplicationUp = false;
            
            Entity.ReplaceWaitReplicationTimeLeft(Entity.WaitReplicationDuration);
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
            Entity.isWaitingReplicationTarget = false;

            Entity.ReplaceTimeLeftForNextReplication(Entity.ReplicationInterval);
            Entity.ReplaceWaitReplicationTimeLeft(Entity.WaitReplicationDuration);
            
            Entity.RabbitVisualChanger.SetWaitTarget(Entity.isWaitingReplicationTarget);
            
            if (Entity.hasReplicationTarget)
                Entity.RemoveReplicationTarget();

            if (Entity.hasChosenForReplicationBy)
                Entity.RemoveChosenForReplicationBy();
        }
    }
}
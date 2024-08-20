using Code.Gameplay.Common.Random;
using Code.Gameplay.Sounds.Config;
using Code.Gameplay.Sounds.Service;

namespace Code.Gameplay.Features.Rabbits.StateMachine.States
{
    public class RabbitReplicationState : EntitySimpleState
    {
        private readonly IAudioService _audioService;

        public RabbitReplicationState(IAudioService audioService)
        {
            _audioService = audioService;
        }
        
        public override void Enter()
        {
            base.Enter();
            
            Entity.ChangeStateToReplication();
            
            if (Entity.hasRabbitAnimator)
                Entity.RabbitAnimator.PlayMoveToReplication();
            
            if (Entity.hasRabbitVisualChanger)
                Entity.RabbitVisualChanger.SetLove();
            
            Entity.isWaitingForMoving = false;
            Entity.isMovingUp = false;
            Entity.isMoving = false;
            Entity.isWaitingForNextReplicationUp = false;
            
            if (Entity.isChosenForReplication == false)
                _audioService.PlayAudio(SoundType.GoToReplication);
            
            Entity.ReplaceWaitReplicationTimeLeft(Entity.WaitReplicationDuration);
        }

        protected override void Exit()
        {
            base.Exit();
            Entity.isChosenForReplication = false;
            Entity.isReplicating = false;
            Entity.isReplicationFinished = false;
            Entity.isNearReplicationTarget = false;

            if (Entity.isReplicationAvailable)
            {
                Entity.isCanBeChosenForReplication = true;
                Entity.isWaitingForNextReplicationUp = true;
                Entity.isCanStartReplication = true;
            }
           
            Entity.isReplicationTimeUp = false;
            Entity.isWaitingReplicationTarget = false;

            Entity.ReplaceTimeLeftForNextReplication(Entity.ReplicationInterval);
            Entity.ReplaceWaitReplicationTimeLeft(Entity.WaitReplicationDuration);
            
            if (Entity.hasRabbitVisualChanger)
                Entity.RabbitVisualChanger.RemoveLove();
                
            if (Entity.hasReplicationTarget)
                Entity.RemoveReplicationTarget();

            if (Entity.hasChosenForReplicationBy)
                Entity.RemoveChosenForReplicationBy();
        }
    }
}
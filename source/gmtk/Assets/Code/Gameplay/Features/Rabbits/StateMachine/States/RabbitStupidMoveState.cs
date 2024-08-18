using Code.Gameplay.Features.Stalls.Services;

namespace Code.Gameplay.Features.Rabbits.StateMachine.States
{
    public class RabbitStupidMoveState : EntitySimpleState
    {
        private readonly IStallService _stallService;

        public RabbitStupidMoveState(IStallService stallService)
        {
            _stallService = stallService;
        }
        
        public override void Enter()
        {
            base.Enter();
            
            Entity.ChangeStateToStupidMove();
            
            Entity.isMovingUp = false;
            Entity.isWaitingForMoving = false;
            Entity.isMoving = true;

            if (Entity.hasRabbitAnimator)
                Entity.RabbitAnimator.PlayMoving();

            Entity.ReplaceTargetPoint(_stallService.GetRandomPositionInStall(Entity.StallParentIndex));
            Entity.ReplaceMoveDirection((Entity.TargetPoint - Entity.WorldPosition).normalized);
        }

        protected override void Exit()
        {
            base.Exit();
            
            if (Entity.hasTargetPoint)
                Entity.RemoveTargetPoint();

            Entity.isMoving = false;
        }
    }
}
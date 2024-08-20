using Code.Gameplay.VFX.Config;
using Code.Gameplay.VFX.Service;

namespace Code.Gameplay.Features.Rabbits.StateMachine.States
{
    public class RabbitDeadState : EntitySimpleState
    {
        private readonly IVFXService _vfxService;

        public RabbitDeadState(IVFXService vfxService)
        {
            _vfxService = vfxService;
        }
        
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
            
            if (Entity.isCarrierOfInfection)
                _vfxService.Spawn(VFXType.SickDeath, Entity.WorldPosition);
            
            if (Entity.isEaten)
                _vfxService.Spawn(VFXType.EatenDeath, Entity.WorldPosition);

            Entity.AddSelfDestructTimer(0.01f);
        }
    }
}
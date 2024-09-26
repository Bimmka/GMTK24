using Code.Gameplay.Sounds.Config;
using Code.Gameplay.Sounds.Service;
using Code.Gameplay.VFX.Config;
using Code.Gameplay.VFX.Service;

namespace Code.Gameplay.Features.Rabbits.StateMachine.States
{
    public class RabbitDeadState : EntitySimpleState
    {
        private readonly IVFXService _vfxService;
        private readonly IAudioService _audioService;

        public RabbitDeadState(IVFXService vfxService, IAudioService audioService)
        {
            _vfxService = vfxService;
            _audioService = audioService;
        }
        
        public override void Enter()
        {
            base.Enter();
            
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
            {
                _vfxService.Spawn(VFXType.SickDeath, Entity.WorldPosition);
                if (Entity.isCarrierOfPoisonInfection)
                    _audioService.PlayAudio(SoundType.DeadByPoison);
                else if (Entity.isCarrierOfRabiesInfection)
                    _audioService.PlayAudio(SoundType.DeadByRabies);
            }

            if (Entity.isEaten)
            {
                _vfxService.Spawn(VFXType.EatenDeath, Entity.WorldPosition);
                _audioService.PlayAudio(SoundType.DeadByEat);
            }

            Entity.AddSelfDestructTimer(0.01f);
        }
    }
}
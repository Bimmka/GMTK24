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
            
            
            
            
        }

        protected override void Exit()
        {
            base.Exit();
           
        }
    }
}
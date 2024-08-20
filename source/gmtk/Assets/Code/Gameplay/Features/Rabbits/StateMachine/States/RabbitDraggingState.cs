using System;
using Code.Gameplay.Sounds.Behaviours;
using Code.Gameplay.Sounds.Config;
using Code.Gameplay.Sounds.Service;

namespace Code.Gameplay.Features.Rabbits.StateMachine.States
{
    public class RabbitDraggingState : EntitySimpleState, IDisposable
    {
        private readonly IAudioService _audioService;
        private SoundElement _soundElement;

        public RabbitDraggingState(IAudioService audioService)
        {
            _audioService = audioService;
        }
        
        public override void Enter()
        {
            base.Enter();
            
            Entity.ChangeStateToDragging();
            
            if (Entity.hasRabbitAnimator)
                Entity.RabbitAnimator.PlayDragging();
            
            Entity.isWaitingForMoving = false;
            Entity.isWaitingForNextReplicationUp = false;
            Entity.isMovementAvailable = false;
            Entity.isCanBeChosenForReplication = false;
            Entity.isSelectable = false;
            
            Entity.ReplaceSelectionDragTimeLeft(Entity.SelectionDragMaxTime);
            
            _soundElement = _audioService.PlayAudio(SoundType.Dragging);
            Entity.ReplaceHuntSoundElement(_soundElement);
        }

        protected override void Exit()
        {
            base.Exit();

            Entity.isDragFinished = false;
            Entity.isDragStarted = false;

            Entity.isSelected = false;
            Entity.isSelectable = true;

            bool isChosenForReplicationBy = Entity.hasChosenForReplicationBy;
            if (isChosenForReplicationBy == false && Entity.isReplicationAvailable && Entity.isAlive)
            {
                Entity.isWaitingForNextReplicationUp = true;
                Entity.isCanBeChosenForReplication = true;
                Entity.isCanStartReplication = true;
            }

            if (Entity.hasAfterDragPosition)
                Entity.RemoveAfterDragPosition();

            if (Entity.hasShiftFromSelect)
                Entity.RemoveShiftFromSelect();

            if (Entity.hasSavedPositionBeforeDrag)
                Entity.RemoveSavedPositionBeforeDrag();

            if (Entity.hasHuntSoundElement && Entity.HuntSoundElement != null)
            {
                Entity.HuntSoundElement.Reset();
                Entity.RemoveHuntSoundElement();
            }
        }
    }
}
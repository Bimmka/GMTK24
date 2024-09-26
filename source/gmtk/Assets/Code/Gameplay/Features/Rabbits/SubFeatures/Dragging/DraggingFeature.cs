using Code.Gameplay.Features.Rabbits.SubFeatures.Dragging.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Dragging
{
    public sealed class DraggingFeature : Feature
    {
        public DraggingFeature(ISystemFactory systems)
        {
            Add(systems.Create<RemoveMovementAvailableAtDragStartedSystem>());
            Add(systems.Create<RemoveMovementComponentsAtDragStartedSystem>());
            Add(systems.Create<RemoveConveyorMarkAtDragStartedSystem>());
            
            Add(systems.Create<PlayDraggingAnimationAtDragStartedSystem>());

            Add(systems.Create<PlaySoundAfterDragStartedSystem>());
            Add(systems.Create<StopPlayingDraggingSoundAtDragFinishedSystem>());
            Add(systems.Create<PlaySoundAfterDragFinishedSystem>());
            Add(systems.Create<RefreshDragReleaseTimeSystem>());

            Add(systems.Create<RemoveOnGroundAfterDragStartedSystem>());
            Add(systems.Create<SetOnGroundAfterDragFinishedSystem>());
            
            Add(systems.Create<ValidateStallParentIndexAfterDragFinishedSystem>());

            Add(systems.Create<CleanupDragStartedMarkSystem>());
            Add(systems.Create<CleanupMovingToConveyorBeltWhenDragFinishedSystem>());
            Add(systems.Create<CleanupDragComponentsWhenDragFinishedSystem>());
            Add(systems.Create<CleanupDragFinishedMarkSystem>());
        }
    }
}
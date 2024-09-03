using Code.Gameplay.Features.Rabbits.SubFeatures.Dragging.Systems;
using Code.Gameplay.Features.Rabbits.SubFeatures.States.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Dragging
{
    public sealed class DraggingFeature : Feature
    {
        public DraggingFeature(ISystemFactory systems)
        {
            Add(systems.Create<RemoveMovementAvailableAtDragStartedSystem>());
            Add(systems.Create<PlayDraggingAnimationAtDragStartedSystem>());

            Add(systems.Create<PlaySoundAfterDragFinishedSystem>());
            Add(systems.Create<RefreshDragReleaseTimeSystem>());

            Add(systems.Create<CleanupDragStartedMarkSystem>());
            Add(systems.Create<CleanupDragComponentsWhenDragFinishedSystem>());
            Add(systems.Create<CleanupDragFinishedMarkSystem>());
        }
    }
}
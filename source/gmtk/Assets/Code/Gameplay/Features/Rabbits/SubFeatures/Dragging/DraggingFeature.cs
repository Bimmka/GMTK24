using Code.Gameplay.Features.Rabbits.SubFeatures.Dragging.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Dragging
{
    public sealed class DraggingFeature : Feature
    {
        public DraggingFeature(ISystemFactory systems)
        {
            Add(systems.Create<PlaySoundAfterDragFinishedSystem>());

            Add(systems.Create<CleanupDragStartedMarkSystem>());
        }
    }
}
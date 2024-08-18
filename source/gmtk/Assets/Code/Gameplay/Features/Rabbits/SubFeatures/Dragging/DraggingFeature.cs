using Code.Gameplay.Features.Rabbits.SubFeatures.Dragging.Systems;
using Code.Gameplay.Features.Rabbits.Systems.Visuals;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Dragging
{
    public sealed class DraggingFeature : Feature
    {
        public DraggingFeature(ISystemFactory systems)
        {
            Add(systems.Create<ApplySelectedVisualSystem>());
            Add(systems.Create<UnapplySelectedVisualSystem>());
            
            Add(systems.Create<CleanupDragStartedMarkSystem>());
        }
    }
}
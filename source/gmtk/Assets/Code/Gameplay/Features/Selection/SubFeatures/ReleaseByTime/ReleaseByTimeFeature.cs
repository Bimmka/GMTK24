using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Selection.SubFeatures.ReleaseByTime
{
    public sealed class ReleaseByTimeFeature : Feature
    {
        public ReleaseByTimeFeature(ISystemFactory systems)
        {
            Add(systems.Create<UpdateReleaseTimeLeftSystem>());
            Add(systems.Create<MarkReleaseUpSelectedEntitiesSystem>());
            Add(systems.Create<CollectReleasedSelectedSystem>());
            Add(systems.Create<ReleaseSelectedSystem>());
            Add(systems.Create<RemoveReleaseUpMarkSystem>());
        }
    }
}
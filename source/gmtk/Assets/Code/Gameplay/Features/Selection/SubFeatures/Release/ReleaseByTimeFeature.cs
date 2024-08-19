using Code.Gameplay.Features.Selection.SubFeatures.Release.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Selection.SubFeatures.Release
{
    public sealed class ReleaseByTimeFeature : Feature
    {
        public ReleaseByTimeFeature(ISystemFactory systems)
        {
            Add(systems.Create<UpdateReleaseTimeLeftSystem>());
            Add(systems.Create<MarkReleaseUpSelectedEntitiesSystem>());

            Add(systems.Create<CollectReleasedSelectedSystem>());
            Add(systems.Create<CollectDeadSelectedSystem>());

            Add(systems.Create<ReleaseSelectedSystem>());
            Add(systems.Create<ReleaseDeadSelectedSystem>());
            Add(systems.Create<RemoveReleaseUpMarkSystem>());
        }
    }
}
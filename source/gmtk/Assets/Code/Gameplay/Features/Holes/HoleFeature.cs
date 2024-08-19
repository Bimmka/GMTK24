using Code.Gameplay.Features.Holes.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Holes
{
    public sealed class HoleFeature : Feature
    {
        public HoleFeature(ISystemFactory systems)
        {
            Add(systems.Create<UpdateSpawnTimeLeftSystem>());
            Add(systems.Create<MarkSpawnUpSystem>());
            Add(systems.Create<SpawnEntitiesSystem>());
            Add(systems.Create<ResetSpawnTimeLeftSystem>());
            Add(systems.Create<RemoveMarkSpawnUpSystem>());
        }
    }
}
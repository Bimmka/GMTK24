using Code.Gameplay.Features.Death.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Death
{
    public sealed class DeathFeature : Feature
    {
        public DeathFeature(ISystemFactory systems)
        {
            Add(systems.Create<MarkDeadByInfectionDeadSystem>());
            Add(systems.Create<MarkDeadWhenEatenSystem>());

            Add(systems.Create<MarkDestructedInfectionForDeadSystem>());
            Add(systems.Create<RemoveStatusesForDeadSystem>());
        }
    }
}
using Code.Gameplay.Features.Rabbits.SubFeatures.Dead.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Dead
{
    public sealed class DeadFeature : Feature
    {
        public DeadFeature(ISystemFactory systems)
        {
            Add(systems.Create<MarkDeadByInfectionDeadSystem>());
            Add(systems.Create<MarkDeadWhenEatenSystem>());

            Add(systems.Create<MarkDestructedInfectionForDeadSystem>());
            Add(systems.Create<RemoveStatusesForDeadSystem>());
        }
    }
}
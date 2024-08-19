using Code.Gameplay.Features.Rabbits.SubFeatures.Rabies.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Rabies
{
    public sealed class RabiesFeature : Feature
    {
        public RabiesFeature(ISystemFactory systems)
        {
            //Add(systems.Create<MarkReplicationBlockedSystem>());
        }
    }
}
using Code.Gameplay.Features.Rabbits.SubFeatures.SimpleMove.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.SimpleMove
{
    public sealed class SimpleMovingFeature : Feature
    {
        public SimpleMovingFeature(ISystemFactory systems)
        {
            Add(systems.Create<RemoveTargetPointWhenReplicationSystem>());
            Add(systems.Create<UpdateTimeForMovingSystem>());
            Add(systems.Create<StartRabbitMovingSystem>());
            Add(systems.Create<RefreshTimeForMovingForReachedTargetSystem>());
            Add(systems.Create<StopRabbitMovingSystem>());
            
            Add(systems.Create<CleanupMovingUpMarkAtMovingToTargetPointSystem>());
        }
    }
}
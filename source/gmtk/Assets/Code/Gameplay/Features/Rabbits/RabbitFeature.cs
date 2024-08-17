using Code.Gameplay.Features.Rabbits.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Rabbits
{
    public sealed class RabbitFeature : Feature
    {
        public RabbitFeature(ISystemFactory systems)
        {
            Add(systems.Create<UpdateTimeForMovingSystem>());
            Add(systems.Create<UpdateTimeForReplicationSystem>());
            
            Add(systems.Create<SetReplicationTargetSystem>());
            
            Add(systems.Create<StarMoveRabbitSystem>());
            Add(systems.Create<StopMoveRabbitSystem>());

            Add(systems.Create<RefreshTimeForMovingForReachedTargetRabbitSystem>());
            
            //cleanup
            Add(systems.Create<CleanupTargetReachedRabbitSystem>());
        }
    }
}
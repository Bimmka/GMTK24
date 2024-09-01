
using Code.Gameplay.Features.Rabbits.SubFeatures.StupidMove.Systems;

using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.StupidMove
{
    public sealed class StupidMovingFeature : Feature
    {
        public StupidMovingFeature(ISystemFactory systems)
        {
            Add(systems.Create<UpdateTimeForMovingSystem>());
            Add(systems.Create<StartRabbitMovingSystem>());
            Add(systems.Create<RefreshTimeForMovingForReachedTargetSystem>());
            Add(systems.Create<StopRabbitMovingSystem>());

            //Add(systems.Create<UpdateActivityFreeMarkSystem>());
            
            Add(systems.Create<CleanupMovingUpMarkAtMovingToTargetPointSystem>());
        }
    }
}
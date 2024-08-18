using Code.Gameplay.Features.Rabbits.SubFeatures.StupidMove.Systems;
using Code.Gameplay.Features.Rabbits.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.StupidMove
{
    public sealed class StupidMovingFeature : Feature
    {
        public StupidMovingFeature(ISystemFactory systems)
        {
            Add(systems.Create<UpdateTimeForMovingSystem>());
            Add(systems.Create<UpdateActivityFreeMarkSystem>());
            Add(systems.Create<MarkMovingFinishedSystem>());
            
            Add(systems.Create<RefreshTimeForMovingForReachedTargetSystem>());

            Add(systems.Create<CleanupMoveFinishedSystem>());
            Add(systems.Create<CleanupTargetPointOnTargetReached>());
        }
    }
}
using Code.Gameplay.Features.Movement.Systems;
using Code.Gameplay.Features.Rabbits.Systems;
using Code.Gameplay.Features.Rabbits.Systems.Visuals;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Rabbits
{
    public sealed class RabbitFeature : Feature
    {
        public RabbitFeature(ISystemFactory systems)
        {
            Add(systems.Create<PrepareForDraggingSystem>());

            Add(systems.Create<UpdateTimeForMovingSystem>());
            Add(systems.Create<UpdateTimeForReplicationSystem>());
            
            Add(systems.Create<UpdateActivityFreeMarkSystem>());
            
            Add(systems.Create<SetReplicationTargetSystem>());

            Add(systems.Create<PrepareToMoveToReplicationTargetSystem>());
            Add(systems.Create<RemoveReplicationTargetComponentWithoutPositionSystem>());
            Add(systems.Create<RemoveReplicationTargetComponentWhenDifferenceStallSystem>());

            Add(systems.Create<MarkNearReplicationTargetSystem>());
            Add(systems.Create<ChangeMovingMarkWhenHasReplicationTargetSystem>());

            Add(systems.Create<UpdateDirectionToReplicationTargetSystem>());
            
            Add(systems.Create<StarMoveRabbitToRandomTargetPointInStallSystem>());

            Add(systems.Create<StartReplicationSystem>());
            Add(systems.Create<UpdateReplicationDurationSystem>());
            Add(systems.Create<SpawnRabbitsAfterReplicationFinishedSystem>());
            
            Add(systems.Create<RefreshTimeForMovingForReachedTargetSystem>());

            Add(systems.Create<ApplySelectedVisualSystem>());

            Add(systems.Create<ResetAfterReplicationFinishedSystem>());
            Add(systems.Create<ResetAfterDraggingSystem>());
            Add(systems.Create<ResetReplicationProcessSystem>());
            
            //cleanup
            Add(systems.Create<CleanupTargetReachedSystem>());
        }
    }
}
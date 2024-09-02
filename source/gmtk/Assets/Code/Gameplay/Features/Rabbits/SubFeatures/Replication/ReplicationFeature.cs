using Code.Gameplay.Features.Rabbits.SubFeatures.Replication.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Replication
{
    public sealed class ReplicationFeature : Feature
    {
        public ReplicationFeature(ISystemFactory systems)
        {
            Add(systems.Create<ApplyReplicationBlockSystem>());
            
            Add(systems.Create<CheckReplicationTargetByReplicationBlockedSystem>());
            Add(systems.Create<CheckReplicationTargetForValidByPositionComponentSystem>());
            Add(systems.Create<CheckReplicationTargetForValidByStallIndexSystem>());

            Add(systems.Create<UpdateTimeForNextReplicationSystem>());

            Add(systems.Create<SetReplicationTargetSystem>());

            Add(systems.Create<MarkWantToReplicateSystem>());
            
            Add(systems.Create<PrepareToMoveToReplicationTargetSystem>());
            Add(systems.Create<UpdateDirectionToReplicationTargetSystem>());
            
            Add(systems.Create<UpdateWaitReplicationTimeSystem>());
            Add(systems.Create<MarkReplicationExpiredTimeSystem>());
            
            Add(systems.Create<StopMoveToReplicationTargetWhenWaitingExpiredSystem>());
            
            //Add(systems.Create<ResetReplicationProcessMarkersForTargetsSystem>());

            Add(systems.Create<SetWaitingReplicationTargetSystem>());
            
            Add(systems.Create<MarkNearReplicationTargetSystem>());
            
            Add(systems.Create<StartReplicationSystem>());

            Add(systems.Create<UpdateReplicationDurationSystem>());

            Add(systems.Create<SpawnRabbitsAfterReplicationFinishedSystem>());
            
            Add(systems.Create<ResetAliveRabbitWhenReplicationFinishedSystem>());
            Add(systems.Create<ResetAliveRabbitWhenInvalidReplicationTargetSystem>());
            Add(systems.Create<ResetNonDraggingReplicationTargetSystem>());
            Add(systems.Create<ResetDraggingReplicationTargetSystem>());

            Add(systems.Create<StopGoToInvalidReplicationTargetSystem>());
            Add(systems.Create<StopReplicationSystem>());
            
            Add(systems.Create<CleanupStartReplicationMarksSystem>());
            Add(systems.Create<CleanupResetReplicationProcessMarkersSystem>());
            Add(systems.Create<CleanupReplicationExpireMarkersSystem>());
        }
    }
}
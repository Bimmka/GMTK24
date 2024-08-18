using Code.Gameplay.Features.Rabbits.SubFeatures.Replication.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Replication
{
    public sealed class ReplicationFeature : Feature
    {
        public ReplicationFeature(ISystemFactory systems)
        {
            Add(systems.Create<UpdateTimeForReplicationSystem>());

            Add(systems.Create<SetReplicationTargetSystem>());

            Add(systems.Create<MarkWantToReplicateSystem>());
            
            //Add(systems.Create<PrepareToMoveToReplicationTargetSystem>());
            Add(systems.Create<RemoveReplicationTargetComponentWithoutPositionSystem>());
            Add(systems.Create<RemoveReplicationTargetComponentWhenDifferenceStallSystem>());
            
            Add(systems.Create<ResetReplicationProcessMarkersForTargetsSystem>());

            Add(systems.Create<MarkNearReplicationTargetSystem>());
            
            Add(systems.Create<UpdateDirectionToReplicationTargetSystem>());
            
            Add(systems.Create<StartReplicationSystem>());
            Add(systems.Create<UpdateReplicationDurationSystem>());
            Add(systems.Create<SpawnRabbitsAfterReplicationFinishedSystem>());
            Add(systems.Create<MarkCanBeChosenForReplicationWhenReplicationFinishedSystem>());
            
            Add(systems.Create<ApplyReplicatingVisualSystem>());
            Add(systems.Create<UnapplyReplicatingVisualSystem>());

            Add(systems.Create<CleanupStartReplicationMarksSystem>());
            Add(systems.Create<CleanupResetReplicationProcessMarkersSystem>());
        }
    }
}
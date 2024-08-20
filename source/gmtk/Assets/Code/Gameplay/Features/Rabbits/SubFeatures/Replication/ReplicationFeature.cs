﻿using Code.Gameplay.Features.Rabbits.SubFeatures.Replication.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Replication
{
    public sealed class ReplicationFeature : Feature
    {
        public ReplicationFeature(ISystemFactory systems)
        {
            Add(systems.Create<ApplyReplicationBlockSystem>());
            
            Add(systems.Create<UpdateTimeForReplicationSystem>());

            Add(systems.Create<SetReplicationTargetSystem>());

            Add(systems.Create<MarkWantToReplicateSystem>());
            
            Add(systems.Create<UpdateWaitReplicationTimeSystem>());
            Add(systems.Create<MarkReplicationExpiredTimeSystem>());
            
            //Add(systems.Create<PrepareToMoveToReplicationTargetSystem>());
            Add(systems.Create<RemoveReplicationTargetComponentWithoutPositionSystem>());
            Add(systems.Create<RemoveReplicationTargetComponentWhenDifferenceStallSystem>());
            Add(systems.Create<RemoveReplicationTargetComponentWhenWaitingExpiredSystem>());
            Add(systems.Create<RemoveReplicationTargetComponentWhenReplicationBlockedSystem>());

            Add(systems.Create<ValidateReplicationNonDraggingTargetSystem>());
            Add(systems.Create<ValidateReplicationDraggingTargetSystem>());
            
            Add(systems.Create<ResetReplicationProcessMarkersForTargetsSystem>());

            Add(systems.Create<SetWaitingReplicationTargetSystem>());
            
            Add(systems.Create<MarkNearReplicationTargetSystem>());
            
            Add(systems.Create<UpdateDirectionToReplicationTargetSystem>());
            
            Add(systems.Create<StartReplicationSystem>());
            Add(systems.Create<UpdateReplicationDurationSystem>());
            Add(systems.Create<SpawnRabbitsAfterReplicationFinishedSystem>());
            Add(systems.Create<MarkCanBeChosenForReplicationWhenReplicationFinishedSystem>());

            Add(systems.Create<CleanupStartReplicationMarksSystem>());
            Add(systems.Create<CleanupResetReplicationProcessMarkersSystem>());
            Add(systems.Create<CleanupReplicationExpireMarkersSystem>());
        }
    }
}
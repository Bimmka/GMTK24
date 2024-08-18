using Code.Gameplay.Features.Rabbits.SubFeatures.Replication.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Replication
{
    public sealed class ReplicationFeature : Feature
    {
        public ReplicationFeature(ISystemFactory systems)
        {
            Add(systems.Create<SetReplicationTargetSystem>());
            
            //Add(systems.Create<PrepareToMoveToReplicationTargetSystem>());
            Add(systems.Create<RemoveReplicationTargetComponentWithoutPositionSystem>());
            Add(systems.Create<RemoveReplicationTargetComponentWhenDifferenceStallSystem>());

            Add(systems.Create<MarkNearReplicationTargetSystem>());
            
            Add(systems.Create<UpdateDirectionToReplicationTargetSystem>());
            
            Add(systems.Create<StartReplicationSystem>());
            Add(systems.Create<UpdateReplicationDurationSystem>());
            Add(systems.Create<SpawnRabbitsAfterReplicationFinishedSystem>());
            
            Add(systems.Create<ResetAfterReplicationFinishedSystem>());
            Add(systems.Create<ResetReplicationProcessSystem>());
        }
    }
}
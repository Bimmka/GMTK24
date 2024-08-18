using Code.Gameplay.Features.Movement.Systems;
using Code.Gameplay.Features.Rabbits.SubFeatures.Angry;
using Code.Gameplay.Features.Rabbits.SubFeatures.Dead;
using Code.Gameplay.Features.Rabbits.SubFeatures.Dragging;
using Code.Gameplay.Features.Rabbits.SubFeatures.Dragging.Systems;
using Code.Gameplay.Features.Rabbits.SubFeatures.Idle;
using Code.Gameplay.Features.Rabbits.SubFeatures.Replication;
using Code.Gameplay.Features.Rabbits.SubFeatures.Replication.Systems;
using Code.Gameplay.Features.Rabbits.SubFeatures.StateMachine;
using Code.Gameplay.Features.Rabbits.SubFeatures.StupidMove;
using Code.Gameplay.Features.Rabbits.SubFeatures.StupidMove.Systems;
using Code.Gameplay.Features.Rabbits.Systems;
using Code.Gameplay.Features.Rabbits.Systems.Visuals;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Rabbits
{
    public sealed class RabbitFeature : Feature
    {
        public RabbitFeature(ISystemFactory systems)
        {
            // Add(systems.Create<PrepareForDraggingSystem>());
            //
            // Add(systems.Create<UpdateTimeForMovingSystem>());
            // Add(systems.Create<UpdateTimeForReplicationSystem>());
            //
            // Add(systems.Create<UpdateActivityFreeMarkSystem>());
            //
            // Add(systems.Create<SetReplicationTargetSystem>());
            //
            //
            // Add(systems.Create<ChangeMovingMarkWhenHasReplicationTargetSystem>());
            //
            // //Add(systems.Create<StarMoveRabbitToRandomTargetPointInStallSystem>());
            //
            //
            //
            // Add(systems.Create<RefreshTimeForMovingForReachedTargetSystem>());
            //
            // Add(systems.Create<ApplySelectedVisualSystem>());
            //
            //
            // Add(systems.Create<ResetAfterDraggingSystem>());
            //

            Add(systems.Create<RabbitStateMachineFeature>());

            Add(systems.Create<UpdateMovingMarkSystem>());

            Add(systems.Create<IdleFeature>());
            Add(systems.Create<AngryFeature>());
            Add(systems.Create<StupidMovingFeature>());
            Add(systems.Create<ReplicationFeature>());
            Add(systems.Create<DraggingFeature>());
            Add(systems.Create<DeadFeature>());
            
            //cleanup
            //Add(systems.Create<CleanupDragStartedMarkSystem>());
        }
    }
}
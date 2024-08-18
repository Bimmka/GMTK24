using Code.Gameplay.Features.Rabbits.SubFeatures.StateMachine.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.StateMachine
{
    public class RabbitStateMachineFeature : Feature
    {
        public RabbitStateMachineFeature(ISystemFactory systems)
        {
            Add(systems.Create<UpdateStateMachineStateSystem>());

            Add(systems.Create<TransitToReplicationStateFromWantToReplicateSystem>());
            Add(systems.Create<TransitToReplicationStateFromReplicatingSystem>());
            
            Add(systems.Create<TransitToStupidMoveStateStateSystem>());
            
            Add(systems.Create<TransitToIdleStateWhenMovingFinishedSystem>());
            Add(systems.Create<TransitToIdleStateWhenReplicationFinishedSystem>());
            Add(systems.Create<TransitToIdleStateWhenReplicationInvalidSystem>());
            Add(systems.Create<TransitToIdleStateWhenDragFinishedSystem>());

            Add(systems.Create<TransitToDraggingStateSystem>());

            Add(systems.Create<TransitToNewStateSystem>());

            Add(systems.Create<CleanupTransitComponentSystem>());
        }
    }
}
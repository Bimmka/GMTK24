using Code.Gameplay.Features.Rabbits.SubFeatures.States.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.States
{
    public sealed class StatesFeature : Feature
    {
        public StatesFeature(ISystemFactory systems)
        {
            Add(systems.Create<PrepareForDraggingSystem>());

            Add(systems.Create<PrepareForReplicationAfterDraggingSystem>());
            Add(systems.Create<PrepareForMovementAfterDraggingSystem>());
            Add(systems.Create<PrepareForSelectionAfterDraggingSystem>());
            
            Add(systems.Create<PrepareForReplicationAfterConveyoringSystem>());
            Add(systems.Create<EnableMovementAfterConveyoringSystem>());
            Add(systems.Create<EnableWaitingMovementAfterConveyoringSystem>());

            Add(systems.Create<ResetAliveRabbitWhenReplicationFinishedSystem>());
            Add(systems.Create<ResetAliveNonDraggingRabbitWhenInvalidReplicationTargetSystem>());
            Add(systems.Create<ResetNonDraggingReplicationTargetSystem>());
            Add(systems.Create<ResetDraggingReplicationTargetSystem>());

            Add(systems.Create<PrepareForConveyoringSystem>());
            
            Add(systems.Create<UpdateInSafetyOrDangerMarkSystem>());
        }
    }
}
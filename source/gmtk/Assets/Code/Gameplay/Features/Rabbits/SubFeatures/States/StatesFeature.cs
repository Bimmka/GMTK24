using Code.Gameplay.Features.Rabbits.SubFeatures.States.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.States
{
    public sealed class StatesFeature : Feature
    {
        public StatesFeature(ISystemFactory systems)
        {
            Add(systems.Create<PrepareForDraggingSystem>());

            Add(systems.Create<PrepareForReplicationAliveRabbitAfterDraggingSystem>());
            Add(systems.Create<PrepareForMovementAliveRabbitAfterDraggingSystem>());
            Add(systems.Create<PrepareForSelectionAliveRabbitAfterDraggingSystem>());

            Add(systems.Create<ResetAliveRabbitWhenReplicationFinishedSystem>());
            Add(systems.Create<ResetAliveNonDraggingRabbitWhenInvalidReplicationTargetSystem>());
            Add(systems.Create<ResetNonDraggingReplicationTargetSystem>());
            Add(systems.Create<ResetDraggingReplicationTargetSystem>());

            Add(systems.Create<UpdateInSafetyOrDangerMarkSystem>());
        }
    }
}
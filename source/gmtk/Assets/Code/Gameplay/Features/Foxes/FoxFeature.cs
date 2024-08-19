using Code.Gameplay.Features.Foxes.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Foxes
{
    public sealed class FoxFeature : Feature
    {
        public FoxFeature(ISystemFactory systems)
        {
            Add(systems.Create<UpdateBeforeNextHuntTimeLeftSystem>());
            Add(systems.Create<MarkHungrySystem>());

            Add(systems.Create<UpdateNextMovingTimeLeftSystem>());
            Add(systems.Create<MarkMovingUpSystem>());
            Add(systems.Create<StartMovingToRandomPointSystem>());
            Add(systems.Create<StopMovingToReachedTargetPointSystem>());
            
            // Add(systems.Create<SetHuntTargetSystem>());
            // Add(systems.Create<MarkHuntStartedSystem>());
            // Add(systems.Create<StopMovingToRandomPointAtHuntStartSystem>());
            //
            // Add(systems.Create<StartMovingToRabbitSystem>());
            // Add(systems.Create<MarkNearRabbitSystem>());
            //
            // Add(systems.Create<MarkStartEatingSystem>());
            // Add(systems.Create<UpdateEatingTimeLeftSystem>());
            // Add(systems.Create<MarkFinishEatingSystem>());
            // Add(systems.Create<RefreshEatingTimeSystem>());
            //
            // Add(systems.Create<UpdateHuntTimeLeftSystem>());
            //
            // Add(systems.Create<MarkHuntFinishedSystem>());
            // Add(systems.Create<MarkWaitingHuntSystem>());
            //Add(systems.Create<RemoveMarkWaitingNextMovingSystem>());
            Add(systems.Create<RemoveMarkMovingUpSystem>());
            Add(systems.Create<RemoveMarkTargetPointReachedSystem>());
        }
    }
}
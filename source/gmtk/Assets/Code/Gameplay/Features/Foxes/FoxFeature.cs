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

            Add(systems.Create<ValidateHuntTargetSystem>());

            Add(systems.Create<SetHuntTargetSystem>());
            Add(systems.Create<MarkHuntStartedSystem>());

            Add(systems.Create<StartMovingToHuntTargetSystem>());
            Add(systems.Create<StopMovingToRandomPointAtHuntStartSystem>());

            Add(systems.Create<UpdateDirectionToHuntTargetSystem>());
            Add(systems.Create<MarkNearHuntTargetSystem>());

            Add(systems.Create<MarkStartEatingSystem>());
            Add(systems.Create<MarkEatingSystem>());
            Add(systems.Create<StartEatingSystem>());
            Add(systems.Create<UpdateEatingTimeLeftSystem>());
            Add(systems.Create<MarkFinishEatingSystem>());
            Add(systems.Create<StopEatingSystem>());
            Add(systems.Create<MarkGotEnoughSystem>());
            Add(systems.Create<RemoveMarkEatingSystem>());
            Add(systems.Create<RefreshEatingTimeSystem>());

            Add(systems.Create<UpdateHuntTimeLeftSystem>());

            Add(systems.Create<MarkHuntFinishedByHuntTimeLeftSystem>());
            Add(systems.Create<MarkHuntFinishedByNoValidTargetsSystem>());
            Add(systems.Create<MarkHuntFinishedWhenGotEnoughSystem>());
            
            Add(systems.Create<RemoveMarkHungryWhenHuntFinishedSystem>());
            
            //Add(systems.Create<RefreshWaitingMovingTimeWhenHuntFinishedSystem>());
            Add(systems.Create<MarkWaitingForMovingAfterHuntFinishedSystem>());

            Add(systems.Create<StopHuntSystem>());

            Add(systems.Create<RemoveMarkInvalidTargetSystem>());
            Add(systems.Create<RemoveMarkMovingUpSystem>());

            Add(systems.Create<RemoveEatingMarksSystem>());

            Add(systems.Create<CleanupHuntHuntSoundWhenHuntFinished>());
            Add(systems.Create<CleanupHuntTargetWhenHuntFinished>());
            
            Add(systems.Create<CleanupMarkHuntStartedSystem>());
            Add(systems.Create<CleanupMarkHuntFinishedSystem>());
        }
    }
}
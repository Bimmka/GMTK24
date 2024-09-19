using Code.Gameplay.Features.Foxes.SubFeatures.Hunt.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Foxes.SubFeatures.Hunt
{
    public sealed class FoxHuntFeature : Feature
    {
        public FoxHuntFeature(ISystemFactory systems)
        {
            Add(systems.Create<UpdateBeforeNextHuntTimeLeftSystem>());
            Add(systems.Create<UpdateTimeBeforeNextHuntAfterClickSystem>());
            Add(systems.Create<MarkHungrySystem>());
            
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
            Add(systems.Create<UpdateHuntTimeAfterClickSystem>());

            Add(systems.Create<MarkHuntFinishedByHuntTimeLeftSystem>());
            Add(systems.Create<MarkHuntFinishedByNoValidTargetsSystem>());
            Add(systems.Create<MarkHuntFinishedWhenGotEnoughSystem>());
            
            Add(systems.Create<RemoveMarkHungryWhenHuntFinishedSystem>());
            
            Add(systems.Create<MarkWaitingForMovingAfterHuntFinishedSystem>());
            
            Add(systems.Create<StopHuntSystem>());

        }
    }
}
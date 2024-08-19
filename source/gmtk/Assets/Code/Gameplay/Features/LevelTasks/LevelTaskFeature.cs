using Code.Gameplay.Features.LevelTasks.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.LevelTasks
{
    public sealed class LevelTaskFeature : Feature
    {
        public LevelTaskFeature(ISystemFactory systems)
        {
            Add(systems.Create<UpdateMinConcreteRabbitAmountTaskTypeSystem>());
            Add(systems.Create<UpdateMinSumRabbitAmountTaskSystem>());
            Add(systems.Create<UpdateRemoveAllRabbitsForTimeTaskSystem>());
            Add(systems.Create<UpdateHoldAmountForPeriodOfTimeTaskSystem>());
            
            Add(systems.Create<UpdateTaskTimeLeftSystem>());
            Add(systems.Create<MarkExpiredTimeSystem>());
            
            
            Add(systems.Create<MarkWaitingHoldTimeWhenConditionCompletedSystem>());
            Add(systems.Create<RemoveWaitingHoldTimeWhenConditionUncompletedSystem>());
            Add(systems.Create<ResetWaitingHoldTimeWhenConditionUncompletedSystem>());
            Add(systems.Create<UpdateLevelTaskHoldDurationSystem>());
            
            Add(systems.Create<MarkTaskHoldDurationCompletedSystem>());
            Add(systems.Create<MarkTaskFailedWhenTimeExpiredSystem>());
            Add(systems.Create<MarkTaskCompletedSystem>());
        }
    }
}
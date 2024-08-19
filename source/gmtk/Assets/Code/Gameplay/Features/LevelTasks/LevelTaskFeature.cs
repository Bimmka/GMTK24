using Code.Gameplay.Features.LevelTasks.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.LevelTasks
{
    public sealed class LevelTaskFeature : Feature
    {
        public LevelTaskFeature(ISystemFactory systems)
        {
            //amount condition
            Add(systems.Create<UpdateTaskConcreteRabbitMinAmountSystem>());
            Add(systems.Create<UpdateTaskConcreteRabbitAmountRangeSystem>());

            Add(systems.Create<UpdateTaskCommonRabbitMinAmountSystem>());
            Add(systems.Create<UpdateTaskCommonRabbitRangeAmountSystem>());
            
            Add(systems.Create<UpdateTaskRemoveAllRabbitsSystem>());
            
            //time condition
            Add(systems.Create<UpdateTaskTimeLeftSystem>());
            Add(systems.Create<MarkExpiredTimeSystem>());
            Add(systems.Create<MarkTimeDurationConditionFailedSystem>());

            Add(systems.Create<UpdateLevelTaskHoldDurationTimeSystem>());
            Add(systems.Create<ResetWaitingHoldTimeWhenAmountConditionUncompletedSystem>());

            Add(systems.Create<MarkHoldDurationTimeConditionCompletedSystem>());

            Add(systems.Create<MarkTimeConditionCompleted>());
            
            //finish task
            Add(systems.Create<MarkTaskFailedWhenTimeExpiredSystem>());
            Add(systems.Create<MarkTaskCompletedSystem>());
            
            Add(systems.Create<UpdateTaskService>());
        }
    }
}
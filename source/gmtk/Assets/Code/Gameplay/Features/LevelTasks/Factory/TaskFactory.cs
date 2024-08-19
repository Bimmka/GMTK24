using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.LevelTasks.Config;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.LevelTasks.Factory
{
    public class TaskFactory : ITaskFactory
    {
        private readonly IIdentifierService _identifierService;

        public TaskFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }
        
        public GameEntity Create(LevelTaskConfig config)
        {
            switch (config.TaskType)
            {
                case LevelTaskType.MinConcreteRabbitAmount:
                    return CreateBaseTask(config.TaskType)
                            .AddMinRabbitAmount(config.MinAmount)
                            .AddCurrentAmount(0)
                            .AddRabbitColorsForTask(config.RabbitColors)
                            .With(x => x.isMinConcreteRabbitAmountTask = true)
                            .With(x => x.isMinConcreteRabbitsAmountTaskType = true)
                        ;
                case LevelTaskType.MinSumRabbitAmount:
                    return CreateBaseTask(config.TaskType)
                            .AddMinRabbitAmount(config.MinAmount)
                            .AddCurrentAmount(0)
                            .With(x => x.isMinSumRabbitAmountTask = true)
                        ;
                case LevelTaskType.HoldAmountForPeriodOfTime:
                    return CreateBaseTask(config.TaskType)
                            .AddMinRabbitAmount(config.MinAmount)
                            .AddMaxRabbitAmount(config.MaxAmount)
                            .AddLevelTaskHoldDuration(config.TimeToHold)
                            .AddLevelTaskHoldDurationTime(0)
                            .AddCurrentAmount(0)
                            .AddRabbitColorsForTask(config.RabbitColors)
                            .With(x => x.isHoldAmountForPeriodOfTimeTask = true)
                            .With(x => x.isLevelTaskHoldDurationTask = true)
                        ;
                case LevelTaskType.RemoveAllRabbitsForTime:
                    return CreateBaseTask(config.TaskType)
                            .AddCurrentAmount(0)
                            .AddLevelTaskDuration(config.TaskDurationTime)
                            .AddLevelTaskDurationTimeLeft(config.TaskDurationTime)
                            .With(x => x.isRemoveAllRabbitsForTimeTask = true)
                            .With(x => x.isLevelTaskForTime = true)
                        ;
                case LevelTaskType.MinRabbitsAmountForTime:
                    return CreateBaseTask(config.TaskType)
                            .AddMinRabbitAmount(config.MinAmount)
                            .AddRabbitColorsForTask(config.RabbitColors)
                            .AddCurrentAmount(0)
                            .AddLevelTaskDuration(config.TaskDurationTime)
                            .AddLevelTaskDurationTimeLeft(config.TaskDurationTime)
                            .With(x => x.isMinRabbitsAmountForTimeTask = true)
                            .With(x => x.isMinConcreteRabbitsAmountTaskType = true)
                            .With(x => x.isLevelTaskForTime = true)
                        ;
                default:
                    throw new ArgumentOutOfRangeException();
            }
          
        }

        private GameEntity CreateBaseTask(LevelTaskType taskType)
        {
            return CreateEntity
                    .Empty()
                    .AddId(_identifierService.Next())
                    .AddLevelTaskType(taskType)
                    .With(x => x.isLevelTask = true)
                    .With(x => x.isUncompleted = true)
                ;
        }
    }
}
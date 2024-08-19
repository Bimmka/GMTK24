using System;
using System.Linq;
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
            GameEntity task = CreateBaseTask(config.TaskType);

            SetupTask(task, config);
            if (config.DurationLimitation.Length > 0)
                AddTimeLimitations(task, config);
            else
                task.isTimeConditionCompleted = true;

            return task;
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

        private GameEntity AddTimeLimitations(GameEntity task, LevelTaskConfig config)
        {
            foreach (LevelTaskDurationLimitationType limitationType in config.DurationLimitation)
            {
                switch (limitationType)
                {
                    case LevelTaskDurationLimitationType.TimeDuration:
                        task
                            .AddLevelTaskDurationBeforeExpired(config.TaskDurationTime)
                            .AddLevelTaskDurationBeforeExpiredTimeLeft(config.TaskDurationTime)
                            .With(x => x.isLevelTaskWithTimeForFail = true)
                            .With(x => x.isTimeDurationConditionCompleted = true)
                            .With(x => x.isTimeConditionUncompleted = true);
                        break;
                    case LevelTaskDurationLimitationType.HoldDuration:
                        task
                            .AddLevelTaskTargetHoldDuration(config.TimeToHold)
                            .AddLevelTaskTargetHoldDurationTime(0)
                            .With(x => x.isLevelTaskWithHoldDuration = true)
                            .With(x => x.isTimeHoldConditionUncompleted = true)
                            .With(x => x.isTimeConditionUncompleted = true);
                        break;
                }
            }

            return task;
        }

        private void SetupTask(GameEntity task, LevelTaskConfig config)
        {
            switch (config.TaskType)
            {
                case LevelTaskType.ConcreteRabbitAmount:
                    task
                        .AddLevelTaskGoalForConcreteRabbits(config.TaskGoalsByRabbitColor)
                        .AddLevelTaskCurrentConcreteRabbitsAmount(config.TaskGoalsByRabbitColor.ToDictionary(x => x.ColorType, x => 0))
                        .With(x => x.isLevelTaskConcreteRabbitAmount = true);
                    switch (config.AmountCondition)
                    {
                        case LevelTaskAmountConditionType.MinAmount:
                            task
                                .AddLevelTaskMinRabbitAmount(config.MinAmount)
                                .With(x => x.isAmountConditionUncompleted = true)
                                .With(x => x.isLevelTaskMinAmountType = true)
                                ;
                            break;
                        case LevelTaskAmountConditionType.RangeAmount:
                            task
                                .AddLevelTaskMinRabbitAmount(0)
                                .AddLevelTaskMaxRabbitAmount(0)
                                .With(x => x.isAmountConditionUncompleted = true)
                                .With(x => x.isLevelTaskRangeAmountType = true)
                                ;
                            break;
                    }
                    break;
                case LevelTaskType.CommonRabbitAmount:
                    task.isLevelTaskCommonRabbitAmount = true;
                    switch (config.AmountCondition)
                    {
                        case LevelTaskAmountConditionType.MinAmount:
                            task
                                .AddLevelTaskCurrentCommonAmount(0)
                                .AddLevelTaskMinRabbitAmount(config.MinAmount)
                                .With(x => x.isAmountConditionUncompleted = true)
                                .With(x => x.isLevelTaskMinAmountType = true)
                                ;
                            break;
                        case LevelTaskAmountConditionType.RangeAmount:
                            task
                                .AddLevelTaskCurrentCommonAmount(0)
                                .AddLevelTaskMinRabbitAmount(0)
                                .AddLevelTaskMaxRabbitAmount(0)
                                .With(x => x.isAmountConditionUncompleted = true)
                                .With(x => x.isLevelTaskRangeAmountType = true)
                                ;
                            break;
                    }
                    break;
                case LevelTaskType.RemoveAllRabbits:
                    task
                        .AddLevelTaskCurrentCommonAmount(0)
                        .With(x => x.isLevelTaskRemoveAllRabbits = true);
                    break;
            }
        }
    }
}
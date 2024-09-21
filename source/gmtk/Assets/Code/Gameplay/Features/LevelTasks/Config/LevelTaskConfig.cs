using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
#if UNITY_EDITOR
using Sirenix.OdinInspector.Editor;
#endif

namespace Code.Gameplay.Features.LevelTasks.Config
{
    [Serializable]
    public class LevelTaskConfig
    {
#if UNITY_EDITOR 
        [OnValueChanged(nameof(ChangeMaxAmountHiddenAvailabilityForTaskGoal))]
#endif
        public LevelTaskType TaskType;
        public LevelTaskDurationLimitationType[] DurationLimitation;
        
        [ShowIf(nameof(IsCanApplyConditionForAmountByTaskType))]
#if UNITY_EDITOR 
        [OnValueChanged(nameof(ChangeMaxAmountHiddenAvailabilityForTaskGoal))]
#endif
        public LevelTaskAmountConditionType AmountCondition;
        
        [ShowIf(nameof(IsConcreteRabbitTaskType))]
#if UNITY_EDITOR
        [OnCollectionChanged(nameof(ChangeMaxAmountAvailable))]
#endif
        public List<TaskGoalByRabbitColor> TaskGoalsByRabbitColor;
        
        [ShowIf(nameof(IsHasTimeDurationLimitation))]
        public float TaskDurationTime;
        
        [ShowIf(nameof(IsHasTimeHoldLimitation))]
        public float TimeToHold;

        [ShowIf(nameof(IsCommonRabbitTaskType))]
        public int MinAmount;
        
        [ShowIf(nameof(IsAvailableMaxAmount))]
        public int MaxAmount;

        private bool IsConcreteRabbitTaskType()
        {
            return TaskType == LevelTaskType.ConcreteRabbitAmount;  
        }
        
        private bool IsCommonRabbitTaskType()
        {
            return TaskType == LevelTaskType.CommonRabbitAmount;  
        }

        private bool IsHasTimeDurationLimitation()
        {
            if (DurationLimitation == null || DurationLimitation.Length == 0)
                return false;

            foreach (LevelTaskDurationLimitationType limitationType in DurationLimitation)
            {
                if (limitationType == LevelTaskDurationLimitationType.TimeDuration)
                    return true;
            }

            return false;
        }
        
        private bool IsHasTimeHoldLimitation()
        {
            if (DurationLimitation == null || DurationLimitation.Length == 0)
                return false;

            foreach (LevelTaskDurationLimitationType limitationType in DurationLimitation)
            {
                if (limitationType == LevelTaskDurationLimitationType.HoldDuration)
                    return true;
            }

            return false;
        }

        private bool IsAvailableMaxAmount()
        {
            return IsCommonRabbitTaskType() && IsRangeAmountCondition();
        }
        
        private bool IsRangeAmountCondition()
        {
            return AmountCondition == LevelTaskAmountConditionType.RangeAmount;  
        }

        private bool IsCanApplyConditionForAmountByTaskType()
        {
            return TaskType != LevelTaskType.RemoveAllRabbits;
        }

#if UNITY_EDITOR
        public void ChangeMaxAmountAvailable(CollectionChangeInfo info, object value)
        {
           ChangeMaxAmountHiddenAvailabilityForTaskGoal();
        }
        
         private void ChangeMaxAmountHiddenAvailabilityForTaskGoal()
        {
            if (TaskType != LevelTaskType.ConcreteRabbitAmount)
                return;

            if (TaskGoalsByRabbitColor == null)
                return;

            foreach (TaskGoalByRabbitColor task in TaskGoalsByRabbitColor)
            {
                task.SetMaxAmountHiddenValue(AmountCondition != LevelTaskAmountConditionType.RangeAmount);
            }
        }
#endif
    }
}
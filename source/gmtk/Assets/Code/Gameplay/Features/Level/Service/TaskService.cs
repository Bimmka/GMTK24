using System;
using Code.Gameplay.Features.LevelTasks.Config;

namespace Code.Gameplay.Features.Level.Service
{
    public class TaskService : ITaskService
    {
        public LevelTaskType TaskType { get; private set; }
        public bool IsCompleted { get; private set; }
        public bool IsFailed { get; private set; }
        public int CurrentAmount { get; private set; }
        public float TaskTimeLeft { get; private set; }
        public float TaskHoldTime { get; private set; }

        public event Action ChangedTaskTimeLeft;
        public event Action ChangedTaskHoldTime;
        public event Action ChangedCurrentAmount;
        public event Action ChangedCompleted;
        public event Action ChangedFailed;

        public void SetTaskType(LevelTaskType taskType)
        {
            TaskType = taskType;
        }
        
        public void UpdateCurrentAmount(int value)
        {
            if (CurrentAmount != value)
            {
                CurrentAmount = value;
                ChangedCurrentAmount?.Invoke();
            }
        }

        public void UpdateTaskTimeLeft(float timeLeft)
        {
            if (Math.Abs(TaskTimeLeft - timeLeft) > MathF.E)
            {
                TaskTimeLeft = timeLeft;
                ChangedTaskTimeLeft?.Invoke();
            }
        }

        public void UpdateTaskHoldTime(float holdTime)
        {
            if (Math.Abs(TaskHoldTime - holdTime) > MathF.E)
            {
                TaskHoldTime = holdTime;
                ChangedTaskHoldTime?.Invoke();
            }
        }
        
        public void UpdateIsCompleted(bool isCompleted)
        {
            if (IsCompleted != isCompleted)
            {
                IsCompleted = isCompleted;
                ChangedCompleted?.Invoke();
            }
        }
        
        public void UpdateIsFailed(bool isFailed)
        {
            if (IsFailed != isFailed)
            {
                IsFailed = isFailed;
                ChangedFailed?.Invoke();
            }
        }
    }
}
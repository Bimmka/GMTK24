using System;
using Code.Gameplay.Features.LevelTasks.Config;

namespace Code.Gameplay.Features.Level.Service
{
    public interface ITaskService
    {
        LevelTaskType TaskType { get; }
        int CurrentAmount { get; }
        float TaskTimeLeft { get; }
        float TaskHoldTime { get; }
        bool IsCompleted { get; }
        bool IsFailed { get; }
        event Action ChangedTaskTimeLeft;
        event Action ChangedTaskHoldTime;
        event Action ChangedCurrentAmount;
        void SetTaskType(LevelTaskType taskType);
        void UpdateCurrentAmount(int value);
        void UpdateTaskTimeLeft(float timeLeft);
        void UpdateTaskHoldTime(float holdTime);
        void UpdateIsCompleted(bool isCompleted);
        event Action ChangedCompleted;
        event Action ChangedFailed;
        void UpdateIsFailed(bool isFailed);
    }
}
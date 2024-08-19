using Code.Gameplay.Features.Level.Service;
using Entitas;

namespace Code.Gameplay.Features.LevelTasks.Systems
{
    public class UpdateTaskService : IExecuteSystem
    {
        private readonly ITaskService _taskService;
        private readonly IGroup<GameEntity> _tasks;

        public UpdateTaskService(GameContext game, ITaskService taskService)
        {
            _taskService = taskService;
            _tasks = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.LevelTask,
                    GameMatcher.LevelTaskType));
        }

        public void Execute()
        {
            foreach (GameEntity task in _tasks)
            {
                _taskService.SetTaskType(task.LevelTaskType);
                
                // if (task.hasCurrentAmount)
                //     _taskService.UpdateCurrentAmount(task.CurrentAmount);
                //
                // if (task.hasLevelTaskDurationTimeLeft)
                //     _taskService.UpdateTaskTimeLeft(task.LevelTaskDurationTimeLeft);
                //
                // if (task.hasLevelTaskHoldDurationTime)
                //     _taskService.UpdateTaskHoldTime(task.LevelTaskHoldDurationTime);
                
                _taskService.UpdateIsCompleted(task.isCompleted);
                _taskService.UpdateIsFailed(task.isFailed);
            }
        }
    }
}
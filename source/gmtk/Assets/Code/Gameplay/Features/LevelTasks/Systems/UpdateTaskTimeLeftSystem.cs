using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.LevelTasks.Systems
{
    public class UpdateTaskTimeLeftSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _tasks;

        public UpdateTaskTimeLeftSystem(GameContext game, ITimeService time)
        {
            _time = time;
            _tasks = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.LevelTaskWithTimeForFail,
                    GameMatcher.Uncompleted,
                    GameMatcher.LevelTaskDurationBeforeExpiredTimeLeft));
        }

        public void Execute()
        {
            foreach (GameEntity task in _tasks)
            {
                task.ReplaceLevelTaskDurationBeforeExpiredTimeLeft(task.LevelTaskDurationBeforeExpiredTimeLeft - _time.DeltaTime);
            }
        }
    }
}
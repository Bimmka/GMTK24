using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.LevelTasks.Systems
{
    public class UpdateLevelTaskHoldDurationTimeSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _tasks;

        public UpdateLevelTaskHoldDurationTimeSystem(GameContext game, ITimeService time)
        {
            _time = time;
            _tasks = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.LevelTask,
                    GameMatcher.LevelTaskWithHoldDuration,
                    GameMatcher.AmountConditionCompleted,
                    GameMatcher.LevelTaskTargetHoldDurationTime));
        }

        public void Execute()
        {
            foreach (GameEntity task in _tasks)
            {
                task.ReplaceLevelTaskTargetHoldDurationTime(task.LevelTaskTargetHoldDurationTime + _time.DeltaTime);
            }
        }
    }
}
using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.LevelTasks.Systems
{
    public class UpdateLevelTaskHoldDurationSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _tasks;

        public UpdateLevelTaskHoldDurationSystem(GameContext game, ITimeService time)
        {
            _time = time;
            _tasks = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.LevelTask,
                    GameMatcher.LevelTaskHoldDurationTask,
                    GameMatcher.WaitingHoldTime,
                    GameMatcher.LevelTaskHoldDurationTime));
        }

        public void Execute()
        {
            foreach (GameEntity task in _tasks)
            {
                task.ReplaceLevelTaskHoldDurationTime(task.LevelTaskHoldDurationTime + _time.DeltaTime);
            }
        }
    }
}
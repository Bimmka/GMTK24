using Entitas;

namespace Code.Gameplay.Features.LevelTasks.Systems
{
    public class MarkTimeDurationConditionFailedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _tasks;

        public MarkTimeDurationConditionFailedSystem(GameContext game)
        {
            _tasks = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.LevelTaskWithTimeForFail,
                    GameMatcher.Uncompleted,
                    GameMatcher.LevelTaskTimeExpired));
        }

        public void Execute()
        {
            foreach (GameEntity task in _tasks)
            {
                task.isTimeDurationConditionFailed = true;
                task.isTimeDurationConditionCompleted = false;
            }
        }
    }
}
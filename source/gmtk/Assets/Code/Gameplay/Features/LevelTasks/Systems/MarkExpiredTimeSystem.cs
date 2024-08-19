using Entitas;

namespace Code.Gameplay.Features.LevelTasks.Systems
{
    public class MarkExpiredTimeSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _tasks;

        public MarkExpiredTimeSystem(GameContext game)
        {
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
                if (task.LevelTaskDurationBeforeExpiredTimeLeft <= 0)
                {
                    task.isLevelTaskTimeExpired = true;
                }
            }
        }
    }
}
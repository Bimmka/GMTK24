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
                    GameMatcher.LevelTaskForTime,
                    GameMatcher.Uncompleted,
                    GameMatcher.LevelTaskDurationTimeLeft));
        }

        public void Execute()
        {
            foreach (GameEntity task in _tasks)
            {
                if (task.LevelTaskDurationTimeLeft <= 0)
                {
                    task.isLevelTaskTimeExpired = true;
                }
            }
        }
    }
}
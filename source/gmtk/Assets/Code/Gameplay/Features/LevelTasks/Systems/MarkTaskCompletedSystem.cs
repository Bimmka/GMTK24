using Entitas;

namespace Code.Gameplay.Features.LevelTasks.Systems
{
    public class MarkTaskCompletedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _tasks;

        public MarkTaskCompletedSystem(GameContext game)
        {
            _tasks = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.LevelTask,
                    GameMatcher.ConditionsCompleted)
                .NoneOf(GameMatcher.LevelTaskHoldDurationTask));
        }

        public void Execute()
        {
            foreach (GameEntity task in _tasks)
            {
                task.isCompleted = true;
            }
        }
    }
}
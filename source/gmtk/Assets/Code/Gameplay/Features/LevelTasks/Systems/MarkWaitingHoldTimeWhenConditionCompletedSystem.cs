using Entitas;

namespace Code.Gameplay.Features.LevelTasks.Systems
{
    public class MarkWaitingHoldTimeWhenConditionCompletedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _tasks;

        public MarkWaitingHoldTimeWhenConditionCompletedSystem(GameContext game)
        {
            _tasks = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.LevelTask,
                    GameMatcher.LevelTaskHoldDurationTask,
                    GameMatcher.ConditionsCompleted));
        }

        public void Execute()
        {
            foreach (GameEntity task in _tasks)
            {
                task.isWaitingHoldTime = true;
            }
        }
    }
}
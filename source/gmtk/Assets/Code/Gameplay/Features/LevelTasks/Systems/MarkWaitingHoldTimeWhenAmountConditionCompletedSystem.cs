using Entitas;

namespace Code.Gameplay.Features.LevelTasks.Systems
{
    public class MarkWaitingHoldTimeWhenAmountConditionCompletedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _tasks;

        public MarkWaitingHoldTimeWhenAmountConditionCompletedSystem(GameContext game)
        {
            _tasks = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.LevelTask,
                    GameMatcher.LevelTaskWithHoldDuration,
                    GameMatcher.AmountConditionCompleted));
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
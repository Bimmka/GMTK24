using Entitas;

namespace Code.Gameplay.Features.LevelTasks.Systems
{
    public class ResetWaitingHoldTimeWhenAmountConditionUncompletedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _tasks;

        public ResetWaitingHoldTimeWhenAmountConditionUncompletedSystem(GameContext game)
        {
            _tasks = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.LevelTask,
                    GameMatcher.LevelTaskWithHoldDuration,
                    GameMatcher.AmountConditionUncompleted,
                    GameMatcher.LevelTaskTargetHoldDurationTime));
        }

        public void Execute()
        {
            foreach (GameEntity task in _tasks)
            {
                task.ReplaceLevelTaskTargetHoldDurationTime(0);
            }
        }
    }
}
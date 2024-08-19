using Entitas;

namespace Code.Gameplay.Features.LevelTasks.Systems
{
    public class ResetWaitingHoldTimeWhenConditionUncompletedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _tasks;

        public ResetWaitingHoldTimeWhenConditionUncompletedSystem(GameContext game)
        {
            _tasks = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.LevelTask,
                    GameMatcher.LevelTaskHoldDurationTask,
                    GameMatcher.ConditionsUncompleted,
                    GameMatcher.LevelTaskHoldDurationTime));
        }

        public void Execute()
        {
            foreach (GameEntity task in _tasks)
            {
                task.ReplaceLevelTaskHoldDurationTime(0);
            }
        }
    }
}
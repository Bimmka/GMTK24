using Entitas;

namespace Code.Gameplay.Features.LevelTasks.Systems
{
    public class RemoveWaitingHoldTimeWhenConditionUncompletedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _tasks;

        public RemoveWaitingHoldTimeWhenConditionUncompletedSystem(GameContext game)
        {
            _tasks = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.LevelTask,
                    GameMatcher.LevelTaskHoldDurationTask,
                    GameMatcher.ConditionsUncompleted));
        }

        public void Execute()
        {
            foreach (GameEntity task in _tasks)
            {
                task.isWaitingHoldTime = false;
            }
        }
    }
}
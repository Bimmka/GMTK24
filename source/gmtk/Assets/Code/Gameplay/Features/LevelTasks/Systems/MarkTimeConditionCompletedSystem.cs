using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.LevelTasks.Systems
{
    public class MarkTimeConditionCompletedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _tasks;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(1);

        public MarkTimeConditionCompletedSystem(GameContext game)
        {
            _tasks = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.LevelTask,
                    GameMatcher.Uncompleted,
                    GameMatcher.TimeConditionUncompleted));
        }

        public void Execute()
        {
            foreach (GameEntity task in _tasks.GetEntities(_buffer))
            {
                bool isTimeConditionCompleted = true;
                if (task.isLevelTaskWithTimeForFail)
                    isTimeConditionCompleted = task.isTimeDurationConditionCompleted;

                if (task.isLevelTaskWithHoldDuration)
                    isTimeConditionCompleted = task.isTimeHoldConditionCompleted;

                if (isTimeConditionCompleted)
                {
                    task.isTimeConditionCompleted = true;
                    task.isTimeConditionUncompleted = false;
                }

            }
        }
    }
}
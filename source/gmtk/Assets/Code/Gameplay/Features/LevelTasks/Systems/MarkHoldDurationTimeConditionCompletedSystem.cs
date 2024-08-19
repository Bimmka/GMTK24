using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.LevelTasks.Systems
{
    public class MarkHoldDurationTimeConditionCompletedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _tasks;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(1);

        public MarkHoldDurationTimeConditionCompletedSystem(GameContext game)
        {
            _tasks = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.LevelTask,
                    GameMatcher.LevelTaskWithHoldDuration,
                    GameMatcher.AmountConditionCompleted,
                    GameMatcher.LevelTaskTargetHoldDuration,
                    GameMatcher.LevelTaskTargetHoldDurationTime));
        }

        public void Execute()
        {
            foreach (GameEntity task in _tasks.GetEntities(_buffer))
            {
                if (task.LevelTaskTargetHoldDurationTime >= task.LevelTaskTargetHoldDuration)
                {
                    task.isTimeHoldConditionCompleted = true;
                    task.isTimeHoldConditionUncompleted = false;
                }
            }
        }
    }
}
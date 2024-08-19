using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.LevelTasks.Systems
{
    public class MarkTaskHoldDurationCompletedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _tasks;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(1);

        public MarkTaskHoldDurationCompletedSystem(GameContext game)
        {
            _tasks = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.LevelTask,
                    GameMatcher.LevelTaskHoldDurationTask,
                    GameMatcher.WaitingHoldTime,
                    GameMatcher.LevelTaskHoldDuration,
                    GameMatcher.LevelTaskHoldDurationTime));
        }

        public void Execute()
        {
            foreach (GameEntity task in _tasks.GetEntities(_buffer))
            {
                if (task.LevelTaskHoldDurationTime >= task.LevelTaskHoldDuration)
                {
                    task.isCompleted = true;
                    task.isUncompleted = false;
                }
            }
        }
    }
}
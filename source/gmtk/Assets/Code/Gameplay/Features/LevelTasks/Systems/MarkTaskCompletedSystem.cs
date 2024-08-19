using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.LevelTasks.Systems
{
    public class MarkTaskCompletedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _tasks;
        private List<GameEntity> _buffer = new List<GameEntity>(1);

        public MarkTaskCompletedSystem(GameContext game)
        {
            _tasks = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.LevelTask,
                    GameMatcher.AmountConditionCompleted,
                    GameMatcher.TimeConditionCompleted,
                    GameMatcher.Uncompleted));
        }

        public void Execute()
        {
            foreach (GameEntity task in _tasks.GetEntities(_buffer))
            {
                task.isCompleted = true;
                task.isUncompleted = false;
            }
        }
    }
}
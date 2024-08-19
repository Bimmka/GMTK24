using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.LevelTasks.Systems
{
    public class MarkTaskFailedWhenTimeExpiredSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _tasks;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(1);

        public MarkTaskFailedWhenTimeExpiredSystem(GameContext game)
        {
            _tasks = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.LevelTaskForTime,
                    GameMatcher.Uncompleted,
                    GameMatcher.LevelTaskTimeExpired));
        }

        public void Execute()
        {
            foreach (GameEntity task in _tasks.GetEntities(_buffer))
            {
                task.isUncompleted = false;
                task.isFailed = true;
            }
        }
    }
}
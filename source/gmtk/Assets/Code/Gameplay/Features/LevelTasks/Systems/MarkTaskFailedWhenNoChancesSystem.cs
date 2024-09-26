using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.LevelTasks.Config;
using Entitas;

namespace Code.Gameplay.Features.LevelTasks.Systems
{
    public class MarkTaskFailedWhenNoChancesSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _tasks;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(1);
        private readonly IGroup<GameEntity> _rabbits;
        private readonly IGroup<GameEntity> _holes;

        public MarkTaskFailedWhenNoChancesSystem(GameContext game)
        {
            _tasks = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.LevelTask,
                    GameMatcher.LevelTaskType,
                    GameMatcher.Uncompleted));

             _rabbits = game.GetGroup(GameMatcher.AllOf(GameMatcher.Rabbit, GameMatcher.Alive));
             _holes = game.GetGroup(GameMatcher.AllOf(GameMatcher.Hole));
        }

        public void Execute()
        {
            foreach (GameEntity task in _tasks.GetEntities(_buffer))
            {
                if (_rabbits.count <= 1 && task.LevelTaskType != LevelTaskType.RemoveAllRabbits && _holes.count == 0)
                {
                    task.isUncompleted = false;
                    task.isFailed = true;
                    
                    CreateEntity.Empty().With(x => x.isLose = true);
                }
            }
        }
    }
}
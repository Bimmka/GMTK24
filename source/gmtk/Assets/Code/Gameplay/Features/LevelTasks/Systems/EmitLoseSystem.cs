using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Entitas;

namespace Code.Gameplay.Features.LevelTasks.Systems
{
    public class EmitLoseSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _tasks;

        public EmitLoseSystem(GameContext game)
        {
            _tasks = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.LevelTaskWithTimeForFail,
                    GameMatcher.Uncompleted,
                    GameMatcher.LevelTaskTimeExpired));
        }

        public void Execute()
        {
            foreach (GameEntity task in _tasks)
            {
                CreateEntity.Empty().With(x => x.isLose = true);
            }
        }
    }
}
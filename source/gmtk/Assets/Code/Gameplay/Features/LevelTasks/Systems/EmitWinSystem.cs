using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Entitas;

namespace Code.Gameplay.Features.LevelTasks.Systems
{
    public class EmitWinSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _tasks;

        public EmitWinSystem(GameContext game)
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
            foreach (GameEntity task in _tasks)
            {
                CreateEntity.Empty().With(x => x.isWin = true);
            }
        }
    }
}
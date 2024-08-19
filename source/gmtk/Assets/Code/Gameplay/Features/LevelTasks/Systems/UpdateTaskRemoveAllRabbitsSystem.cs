using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.LevelTasks.Systems
{
    public class UpdateTaskRemoveAllRabbitsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _tasks;
        private readonly IGroup<GameEntity> _rabbits;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(1);

        public UpdateTaskRemoveAllRabbitsSystem(GameContext game)
        {
            _tasks = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.LevelTask,
                    GameMatcher.LevelTaskRemoveAllRabbits,
                    GameMatcher.LevelTaskCurrentCommonAmount,
                    GameMatcher.Uncompleted));

            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.Alive));
        }

        public void Execute()
        {
            foreach (GameEntity task in _tasks.GetEntities(_buffer))
            {
                int rabbitAmount = _rabbits.count;
                bool isAmountConditionCompleted = rabbitAmount == 0;
                task.isAmountConditionCompleted = isAmountConditionCompleted;
                task.isAmountConditionUncompleted = isAmountConditionCompleted == false;
                
                task.ReplaceLevelTaskCurrentCommonAmount(rabbitAmount);
            }
        }
    }
}
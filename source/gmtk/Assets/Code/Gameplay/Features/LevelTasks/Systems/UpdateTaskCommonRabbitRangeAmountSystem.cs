using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.LevelTasks.Systems
{
    public class UpdateTaskCommonRabbitRangeAmountSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _tasks;
        private readonly IGroup<GameEntity> _rabbits;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(1);

        public UpdateTaskCommonRabbitRangeAmountSystem(GameContext game)
        {
            _tasks = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.LevelTask,
                    GameMatcher.LevelTaskCommonRabbitAmount,
                    GameMatcher.LevelTaskRangeAmountType,
                    GameMatcher.Uncompleted,
                    GameMatcher.LevelTaskMaxRabbitAmount,
                    GameMatcher.LevelTaskMinRabbitAmount,
                    GameMatcher.LevelTaskCurrentCommonAmount));

            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.Alive));
        }

        public void Execute()
        {
            foreach (GameEntity task in _tasks.GetEntities(_buffer))
            {
                bool isAmountConditionComplete = (_rabbits.count >= task.LevelTaskMinRabbitAmount && _rabbits.count <= task.LevelTaskMaxRabbitAmount);
                task.isAmountConditionCompleted = isAmountConditionComplete;
                task.isAmountConditionUncompleted = isAmountConditionComplete == false;
                
                task.ReplaceLevelTaskCurrentCommonAmount(_rabbits.count);
            }
        }
    }
}
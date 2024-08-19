using System.Collections.Generic;
using Code.Common.EntityIndices;
using Code.Gameplay.Features.LevelTasks.Config;
using Entitas;

namespace Code.Gameplay.Features.LevelTasks.Systems
{
    public class UpdateTaskConcreteRabbitAmountRangeSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _tasks;
        private readonly IGroup<GameEntity> _rabbits;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(1);

        public UpdateTaskConcreteRabbitAmountRangeSystem(GameContext game)
        {
            _game = game;
            _tasks = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.LevelTask,
                    GameMatcher.LevelTaskConcreteRabbitAmount,
                    GameMatcher.LevelTaskRangeAmountType,
                    GameMatcher.Uncompleted,
                    GameMatcher.LevelTaskGoalForConcreteRabbits,
                    GameMatcher.LevelTaskCurrentConcreteRabbitsAmount));
        }

        public void Execute()
        {
            foreach (GameEntity task in _tasks.GetEntities(_buffer))
            {
                bool isHaveUncompletedAmount = false;
                foreach (TaskGoalByRabbitColor goalByColor in task.LevelTaskGoalForConcreteRabbits)
                {
                    var rabbits = _game.RabbitsByColor(goalByColor.ColorType);

                    task.LevelTaskCurrentConcreteRabbitsAmount[goalByColor.ColorType] = rabbits.Count;

                    if (rabbits.Count < goalByColor.MinAmount || rabbits.Count > goalByColor.MaxAmount)
                        isHaveUncompletedAmount = true;
                }

                task.isAmountConditionCompleted = isHaveUncompletedAmount == false;
                task.isAmountConditionUncompleted = isHaveUncompletedAmount;
            }
        }
    }
}
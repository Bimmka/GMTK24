using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.LevelTasks.Systems
{
    public class UpdateHoldAmountForPeriodOfTimeTaskSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _tasks;
        private readonly IGroup<GameEntity> _rabbits;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(1);

        public UpdateHoldAmountForPeriodOfTimeTaskSystem(GameContext game)
        {
            _tasks = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.HoldAmountForPeriodOfTimeTask,
                    GameMatcher.RabbitColorsForTask,
                    GameMatcher.MinRabbitAmount,
                    GameMatcher.MaxRabbitAmount,
                    GameMatcher.CurrentAmount,
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
                int amountForTask = 0;

                foreach (GameEntity rabbit in _rabbits)
                {
                    if (task.RabbitColorsForTask.Contains(rabbit.RabbitColorType))
                        amountForTask++;
                }

                bool isConditionCompleted = amountForTask >= task.MinRabbitAmount && amountForTask <= task.MaxRabbitAmount;
                task.isConditionsCompleted = isConditionCompleted;
                task.isConditionsUncompleted = isConditionCompleted == false;

                task.ReplaceCurrentAmount(amountForTask);
            }
        }
    }
}
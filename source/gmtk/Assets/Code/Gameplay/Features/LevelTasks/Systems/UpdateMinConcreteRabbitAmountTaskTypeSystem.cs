using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.LevelTasks.Systems
{
    public class UpdateMinConcreteRabbitAmountTaskTypeSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _tasks;
        private readonly IGroup<GameEntity> _rabbits;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(1);

        public UpdateMinConcreteRabbitAmountTaskTypeSystem(GameContext game)
        {
            _tasks = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.LevelTask,
                    GameMatcher.MinConcreteRabbitsAmountTaskType,
                    GameMatcher.Uncompleted,
                    GameMatcher.MinRabbitAmount,
                    GameMatcher.CurrentAmount,
                    GameMatcher.RabbitColorsForTask));

            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                GameMatcher.Rabbit,
                GameMatcher.RabbitColorType,
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

                if (amountForTask >= task.MinRabbitAmount)
                {
                    task.isCompleted = true;
                    task.isUncompleted = false;
                }

                task.ReplaceCurrentAmount(amountForTask);
            }
        }
    }
}
using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.LevelTasks.Systems
{
    public class UpdateMinSumRabbitAmountTaskSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _tasks;
        private readonly IGroup<GameEntity> _rabbits;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(1);

        public UpdateMinSumRabbitAmountTaskSystem(GameContext game)
        {
            _tasks = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.LevelTask,
                    GameMatcher.MinSumRabbitAmountTask,
                    GameMatcher.Uncompleted,
                    GameMatcher.MinRabbitAmount,
                    GameMatcher.CurrentAmount));

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
                if (rabbitAmount >= task.MinRabbitAmount)
                {
                    task.isCompleted = true;
                    task.isUncompleted = false;
                }

                task.ReplaceCurrentAmount(rabbitAmount);
            }
        }
    }
}
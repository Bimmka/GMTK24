using Code.Common.Entity;
using Code.Common.Extensions;
using Entitas;

namespace Code.Gameplay.Features.LevelTasks.Systems
{
    public class UpdateTaskStatusPanelSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _tasks;
        private readonly IGroup<GameEntity> _statusPanels;

        public UpdateTaskStatusPanelSystem(GameContext game)
        {
            _tasks = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.LevelTask,
                    GameMatcher.Uncompleted));

            _statusPanels = game.GetGroup(GameMatcher.GameTaskStatusPanel);
        }

        public void Execute()
        {
            foreach (GameEntity task in _tasks)
            {
                foreach (GameEntity statusPanel in _statusPanels)
                {
                    statusPanel.GameTaskStatusPanel.UpdateByEntity(task);
                }
            }
        }
    }
}
using Code.Gameplay.Features.LevelTasks.Config;

namespace Code.Gameplay.Features.LevelTasks.Factory
{
    public interface ITaskFactory
    {
        GameEntity Create(LevelTaskConfig config);
    }
}
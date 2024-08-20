using Code.Gameplay.Levels;
using Code.Progress.Provider;
using Code.Progress.SaveLoad;
using Entitas;

namespace Code.Gameplay.Features.LevelFinish.Systems
{
    public class SaveLevelAsCompletedSystem : IExecuteSystem
    {
        private readonly ILevelDataProvider _levelProvider;
        private readonly IProgressProvider _progressProvider;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IGroup<GameEntity> _wins;
        

        public SaveLevelAsCompletedSystem(
            GameContext game,
            ILevelDataProvider levelProvider,
            IProgressProvider progressProvider,
            ISaveLoadService saveLoadService)
        {
            _levelProvider = levelProvider;
            _progressProvider = progressProvider;
            _saveLoadService = saveLoadService;;
            _wins = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Win));
        }

        public void Execute()
        {
            foreach (GameEntity win in _wins)
            {
                string levelId = _levelProvider.CurrentId;
                if (_progressProvider.ProgressData.PassedLevels.Contains(levelId) == false)
                {
                    _progressProvider.ProgressData.PassedLevels.Add(levelId);
                    _saveLoadService.SaveProgress();
                }
            }
        }
    }
}
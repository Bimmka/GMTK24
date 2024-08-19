using Code.Gameplay.Windows.Base;
using Code.Gameplay.Windows.Service;
using Entitas;

namespace Code.Gameplay.Features.LevelFinish.Systems
{
    public class OpenWinWindowSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _wins;
        private readonly IWindowService _windowService;

        public OpenWinWindowSystem(GameContext game, IWindowService windowService)
        {
            _windowService = windowService;
            _wins = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Win));
        }

        public void Execute()
        {
            foreach (GameEntity win in _wins)
            {
                _windowService.Open(WindowId.Win);
            }
        }
    }
}
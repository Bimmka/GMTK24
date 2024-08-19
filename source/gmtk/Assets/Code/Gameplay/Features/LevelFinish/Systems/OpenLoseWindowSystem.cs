using Code.Gameplay.Windows.Base;
using Code.Gameplay.Windows.Service;
using Entitas;

namespace Code.Gameplay.Features.LevelFinish.Systems
{
    public class OpenLoseWindowSystem : IExecuteSystem
    {
        private readonly IWindowService _windowService;
        private readonly IGroup<GameEntity> _loses;

        public OpenLoseWindowSystem(GameContext game, IWindowService windowService)
        {
            _windowService = windowService;
            _loses = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Lose));
        }

        public void Execute()
        {
            foreach (GameEntity lose in _loses)
            {
                _windowService.Open(WindowId.Lose);
            }
        }
    }
}
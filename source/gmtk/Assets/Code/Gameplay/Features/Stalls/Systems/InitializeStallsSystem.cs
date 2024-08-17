using Code.Gameplay.StaticData;
using Entitas;

namespace Code.Gameplay.Features.Stalls.Systems
{
    public class InitializeStallsSystem : IInitializeSystem
    {
        private readonly GameContext _game;

        public InitializeStallsSystem(GameContext game, IStaticDataService staticDataService)
        {
            _game = game;
        }

        public void Initialize()
        {
            
        }
    }
}
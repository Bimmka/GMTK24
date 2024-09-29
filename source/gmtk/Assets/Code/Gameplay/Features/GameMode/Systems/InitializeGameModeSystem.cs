using Code.Common.Entity;
using Code.Common.Extensions;
using Entitas;

namespace Code.Gameplay.Features.GameMode
{
    public class InitializeGameModeSystem : IInitializeSystem
    {

        public InitializeGameModeSystem()
        {

        }

        public void Initialize()
        {
            CreateEntity.Empty()
                .With(x => x.isModeHandler = true)
                .With(x => x.isGameplayMode = true);
        }
    }
}
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.GameMode
{
    public sealed class GameModeFeature : Feature
    {
        public GameModeFeature(ISystemFactory systems)
        {
            Add(systems.Create<InitializeGameModeSystem>());


            Add(systems.Create<SwitchToBuildingModeSystem>());
            Add(systems.Create<SwitchToGameplayModeSystem>());


            Add(systems.Create<CleanupModeSwitchedMarkSystem>());
        }
    }
}
using Entitas;

namespace Code.Gameplay.Features.GameMode
{
    [Game] public class BuildingMode : IComponent {}
    [Game] public class GameplayMode : IComponent {}
    [Game] public class ModeHandler : IComponent {}
    [Game] public class ModeSwitched : IComponent {}
}
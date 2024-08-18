using Code.Gameplay.Input.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Input
{
  public class InputFeature : Feature
  {
    public InputFeature(ISystemFactory systems)
    {
      Add(systems.Create<InitializeInputSystem>());
        
      Add(systems.Create<UpdateMousePositionSystem>());
      Add(systems.Create<EmitInputSystem>());

      Add(systems.Create<UpdateLastMouseDownTimeSystem>());
      Add(systems.Create<SaveFirstMouseDownPositionSystem>());

      Add(systems.Create<MarkWasDraggingSystem>());
      Add(systems.Create<MarkDraggingSystem>());
      Add(systems.Create<EmitLongTapSystem>());
      Add(systems.Create<EmitClickSystem>());

      Add(systems.Create<CleanupClicksSystem>());
      Add(systems.Create<CleanupLongTapsSystem>());
    }
  }
}
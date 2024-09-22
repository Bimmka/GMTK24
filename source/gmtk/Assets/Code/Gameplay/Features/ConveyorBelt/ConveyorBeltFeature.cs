using Code.Gameplay.Features.ConveyorBelt.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.ConveyorBelt
{
   public sealed class ConveyorBeltFeature : Feature
   {
      public ConveyorBeltFeature(ISystemFactory systems)
      {
         Add(systems.Create<PutElementsOnSystem>());
         Add(systems.Create<RemoveInvalidElementsSystem>());
         Add(systems.Create<MoveElementsSystem>());
         Add(systems.Create<FinishElementMoveSystem>());
      }
   }
}
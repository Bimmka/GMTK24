using Code.Gameplay.Features.Statuses.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Statuses
{
  public sealed class StatusFeature : Feature
  {
    public StatusFeature(ISystemFactory systems)
    {
      Add(systems.Create<StatusDurationSystem>());
      
      Add(systems.Create<ApplyPoisonStatusSystem>());
      Add(systems.Create<UnapplyPoisonStatusSystem>());
      
      Add(systems.Create<ApplyRabiesStatusSystem>());
      Add(systems.Create<UnapplyRabiesStatusSystem>());
      
      //Add(systems.Create<StatusVisualsFeature>());
      
      Add(systems.Create<CleanupUnappliedStatusLinkedChanges>());
      Add(systems.Create<CleanupUnappliedStatuses>());
    }
  }
}
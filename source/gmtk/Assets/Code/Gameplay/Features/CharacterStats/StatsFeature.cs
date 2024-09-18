using Code.Gameplay.Features.CharacterStats.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.CharacterStats
{
  public sealed class StatsFeature : Feature
  {
    public StatsFeature(ISystemFactory systems)
    {
      Add(systems.Create<StatChangeSystem>());
      
      Add(systems.Create<ApplySpeedFromStatsSystem>());
      Add(systems.Create<ApplyDragReleaseDurationFromStatsSystem>());
      Add(systems.Create<ApplyReplicationDurationFromStatsSystem>());
      Add(systems.Create<ApplyMovingIntervalStatsSystem>());
      Add(systems.Create<ApplyHuntDurationFromStatsSystem>());
      Add(systems.Create<ApplyRabbitToGetEnoughFromStatsSystem>());
      Add(systems.Create<ApplyBeforeNextHuntTimeFromStatsSystem>());
    }
  }
}
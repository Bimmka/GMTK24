using Code.Common.Destruct;
using Code.Gameplay.Features.CharacterStats;
using Code.Gameplay.Features.ClickHandle;
using Code.Gameplay.Features.ConveyorBelt;
using Code.Gameplay.Features.Death;
using Code.Gameplay.Features.Death.Systems;
using Code.Gameplay.Features.Foxes;
using Code.Gameplay.Features.Holes;
using Code.Gameplay.Features.Infections;
using Code.Gameplay.Features.LevelFinish;
using Code.Gameplay.Features.LevelTasks;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.Rabbits;
using Code.Gameplay.Features.Selection;
using Code.Gameplay.Features.Stalls;
using Code.Gameplay.Features.Statuses;
using Code.Gameplay.Features.TargetCollection;
using Code.Gameplay.Input;
using Code.Infrastructure.Systems;
using Code.Infrastructure.View;

namespace Code.Gameplay
{
  public class BattleFeature : Feature
  {
    public BattleFeature(ISystemFactory systems)
    {
      Add(systems.Create<InputFeature>());
      Add(systems.Create<ClickHandleFeature>());
      Add(systems.Create<BindViewFeature>());
      
      Add(systems.Create<StallFeature>());
      
      Add(systems.Create<LevelTaskFeature>());

      Add(systems.Create<HoleFeature>());
      
      Add(systems.Create<CollectTargetsFeature>());

      Add(systems.Create<StatsFeature>());
      Add(systems.Create<SelectionFeature>());

      Add(systems.Create<ConveyorBeltFeature>());
      Add(systems.Create<MovementFeature>());

      Add(systems.Create<FoxFeature>());
      Add(systems.Create<RabbitFeature>());
      
      Add(systems.Create<InfectionFeature>());
      Add(systems.Create<StatusFeature>());

      Add(systems.Create<DeathFeature>());

      Add(systems.Create<LevelFinishFeature>());

      Add(systems.Create<CleanupSoundsFromDeadSystem>());
      Add(systems.Create<CleanupSoundsFromDestructedSystem>());
      
      Add(systems.Create<ProcessDestructedFeature>());
    }
  }
}
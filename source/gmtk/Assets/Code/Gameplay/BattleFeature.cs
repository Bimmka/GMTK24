using Code.Common.Destruct;
using Code.Gameplay.Features.CharacterStats;
using Code.Gameplay.Features.Foxes;
using Code.Gameplay.Features.Holes;
using Code.Gameplay.Features.Infections;
using Code.Gameplay.Features.LevelTasks;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.Rabbits;
using Code.Gameplay.Features.Selection;
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
      Add(systems.Create<BindViewFeature>());
      
      Add(systems.Create<LevelTaskFeature>());

      Add(systems.Create<HoleFeature>());

      Add(systems.Create<StatsFeature>());
      Add(systems.Create<SelectionFeature>());

      Add(systems.Create<MovementFeature>());

      Add(systems.Create<FoxFeature>());
      Add(systems.Create<RabbitFeature>());
      
      Add(systems.Create<InfectionFeature>());
      Add(systems.Create<CollectTargetsFeature>());
      Add(systems.Create<StatusFeature>());

      Add(systems.Create<ProcessDestructedFeature>());
    }
  }
}
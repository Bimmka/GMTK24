using Code.Common.Destruct;
using Code.Gameplay.Features.CharacterStats;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.Rabbits;
using Code.Gameplay.Features.Selection;
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

      Add(systems.Create<StatsFeature>());
      Add(systems.Create<SelectionFeature>());

      Add(systems.Create<MovementFeature>());
      Add(systems.Create<RabbitFeature>());

      Add(systems.Create<ProcessDestructedFeature>());
    }
  }
}
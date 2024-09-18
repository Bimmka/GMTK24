using System.Collections.Generic;
using Code.Common.Entity;
using Code.Gameplay.Features.Infections.Configs;
using Code.Gameplay.StaticData;
using Entitas;

namespace Code.Gameplay.Features.Statuses.Systems
{
  public class ApplyPoisonStatusSystem : IExecuteSystem
  {
    private readonly GameContext _game;
    private readonly IStaticDataService _staticDataService;
    private readonly IGroup<GameEntity> _statuses;
    private readonly List<GameEntity> _buffer = new(32);

    public ApplyPoisonStatusSystem(GameContext game, IStaticDataService staticDataService)
    {
      _game = game;
      _staticDataService = staticDataService;
      _statuses = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Id,
          GameMatcher.Status,
          GameMatcher.PoisonStatus,
          GameMatcher.TargetId,
          GameMatcher.EffectValue,
          GameMatcher.ValidStatus)
        .NoneOf(GameMatcher.Affected));
    }

    public void Execute()
    {
      foreach (GameEntity status in _statuses.GetEntities(_buffer))
      {
        GameEntity targetEntity = _game.GetEntityWithId(status.TargetId);
                
        if (targetEntity == null)
          continue;
        
        StatInfluenceData[] statInfluenceData = _staticDataService
          .GetInfectionConfig(
            InfectionType.PoisonInfection,
            targetEntity.isRabbit ? InfectionTargetType.Rabbit : InfectionTargetType.Fox)
          .InfectionSetup.StatInfluenceData;

        foreach (StatInfluenceData influenceData in statInfluenceData)
        {
          CreateEntity.Empty()
            .AddStatChange(influenceData.StatType)
            .AddTargetId(status.TargetId)
            .AddEffectValue(influenceData.EffectValue)
            .AddApplierStatusLink(status.Id);
        }

        targetEntity.isCarrierOfInfection = true;
        targetEntity.isCarrierOfPoisonInfection = true;
        targetEntity.isCanBeInfectedByPoison = false;
        
        status.isAffected = true;
        
        if (targetEntity.hasSickVisualChanger)
          targetEntity.SickVisualChanger.SetSick();
      }
    }
  }
}
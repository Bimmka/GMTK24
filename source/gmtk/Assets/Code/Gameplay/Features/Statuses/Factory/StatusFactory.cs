using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.Statuses.Factory
{
  public class StatusFactory : IStatusFactory
  {
    private readonly IIdentifierService _identifiers;

    public StatusFactory(IIdentifierService identifiers)
    {
      _identifiers = identifiers;
    }

    public GameEntity CreateStatus(StatusSetup setup, int targetId)
    {
      GameEntity status;
      switch (setup.StatusType)
      {
        case StatusTypeId.Poison:
          status = CreatePoisonStatus(setup, targetId);
          break;
        case StatusTypeId.Rabies:
          status = CreateRabiesStatus(setup, targetId);
          break;
        default:
          throw new Exception($"Status with type id {setup.StatusType} does not exist");
      }

      status
        .With(x => x.AddDuration(setup.Duration), when: setup.Duration > 0)
        .With(x => x.AddTimeLeft(setup.Duration), when: setup.Duration > 0)
        ;
      
      return status;
    }

    private GameEntity CreatePoisonStatus(StatusSetup setup, int targetId)
    {
      return CreateEntity.Empty()
        .AddId(_identifiers.Next())
        .AddStatusTypeId(StatusTypeId.Poison)
        .AddEffectValue(setup.Value)
        .AddTargetId(targetId)
        .With(x => x.isStatus = true)
        .With(x => x.isPoisonStatus = true)
        ;
    }

    private GameEntity CreateRabiesStatus(StatusSetup setup, int targetId)
    {
      return CreateEntity.Empty()
        .AddId(_identifiers.Next())
        .AddStatusTypeId(StatusTypeId.Rabies)
        .AddEffectValue(setup.Value)
        .AddTargetId(targetId)
        .With(x => x.isStatus = true)
        .With(x => x.isRabiesStatus = true)
        ;
    }
  }
}
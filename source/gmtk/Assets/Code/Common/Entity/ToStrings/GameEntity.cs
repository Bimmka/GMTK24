using System;
using System.Linq;
using System.Text;
using Code.Common.Entity.ToStrings;
using Code.Common.Extensions;
using Code.Gameplay.Features.Infections;
using Code.Gameplay.Features.Rabbits;
using Code.Gameplay.Features.Statuses;
using Entitas;
using UnityEngine;

// ReSharper disable once CheckNamespace
public sealed partial class GameEntity : INamedEntity
{
  private EntityPrinter _printer;

  public override string ToString()
  {
    if (_printer == null)
      _printer = new EntityPrinter(this);

    _printer.InvalidateCache();

    return _printer.BuildToString();
  }

  public string EntityName(IComponent[] components)
  {
    try
    {
      if (components.Length == 1)
        return components[0].GetType().Name;

      foreach (IComponent component in components)
      {
        switch (component.GetType().Name)
        {
          case nameof(Rabbit):
            return PrintRabbit();
          case nameof(Code.Gameplay.Features.CharacterStats.StatChange):
            return PrintStatChange();
          case nameof(Infection):
            return PrintInfection();
          case nameof(Status):
            return PrintStatus();
        }
      }
    }
    catch (Exception exception)
    {
      Debug.LogError(exception.Message);
    }

    return components.First().GetType().Name;
  }

  private string PrintRabbit()
  {
    return new StringBuilder($"Rabbit ")
      .With(s => s.Append($"Id:{Id}"), when: hasId)
      .ToString();
  }
  
  private string PrintStatChange()
  {
    return new StringBuilder($"State Change ")
      .With(s => s.Append($"To:{TargetId}"), when: hasTargetId)
      .ToString();
  }
  
  private string PrintInfection()
  {
    return new StringBuilder($"Infection ")
      .With(s => s.Append($"By Level"), when: isLevelInfection)
      .With(s => s.Append($"By: {CarrierOfInfectionId}"), when: hasCarrierOfInfectionId)
      .ToString();
  }
  
  private string PrintStatus()
  {
    return new StringBuilder($"Status ")
      .With(s => s.Append($"Type {StatusTypeId}"), when: hasStatusTypeId)
      .With(s => s.Append($"To: {TargetId}"), when: hasTargetId)
      .ToString();
  }
  
  public string BaseToString() => base.ToString();
}
using System;
using Code.Gameplay.Features.Infections.Configs;

namespace Code.Gameplay.Features.Statuses
{
  [Serializable]
  public class StatusSetup
  {
    public StatusTypeId StatusType;
    public float Value;
    public float Duration;
  }
}
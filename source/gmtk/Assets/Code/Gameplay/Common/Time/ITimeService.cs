using System;

namespace Code.Gameplay.Common.Time
{
  public interface ITimeService
  {
    float DeltaTime { get; }
    float Time { get; }
    DateTime UtcNow { get; }
    void StopTime();
    void StartTime();
  }
}
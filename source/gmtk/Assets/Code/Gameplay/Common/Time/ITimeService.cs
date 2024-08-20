using System;

namespace Code.Gameplay.Common.Time
{
  public interface ITimeService
  {
    float DeltaTime { get; }
    float Time { get; }
    DateTime UtcNow { get; }
    bool IsPaused { get; }
    void StopTime();
    void StartTime();
  }
}
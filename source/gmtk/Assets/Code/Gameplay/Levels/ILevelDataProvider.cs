using UnityEngine;

namespace Code.Gameplay.Levels
{
  public interface ILevelDataProvider
  {
    Vector3 StartPoint { get; }
    Transform StallSpawnParent { get; }
    string CurrentId { get; }
    Transform RabbitSpawnParent { get; }
    Transform FoxSpawnParent { get; }
    Transform HoleSpawnParent { get; }

    void SetStartPoint(Vector3 startPoint);
    void SetStallSpawnParent(Transform stallSpawnParent);
    void SetRabbitSpawnParent(Transform rabbitSpawnParent);
    void SetFoxSpawnParent(Transform foxSpawnParent);
    void SetCurrentId(string id);
    void SetHoleSpawnParent(Transform holeSpawnParent);
  }
}
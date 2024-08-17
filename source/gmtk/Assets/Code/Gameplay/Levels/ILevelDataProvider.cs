using UnityEngine;

namespace Code.Gameplay.Levels
{
  public interface ILevelDataProvider
  {
    Vector3 StartPoint { get; }
    Transform StallSpawnParent { get; }
    string CurrentId { get; }
    Transform RabbitSpawnParent { get; }

    void SetStartPoint(Vector3 startPoint);
    void SetStallSpawnParent(Transform stallSpawnParent);
    void SetRabbitSpawnParent(Transform rabbitSpawnParent);
    void SetCurrentId(string id);
  }
}
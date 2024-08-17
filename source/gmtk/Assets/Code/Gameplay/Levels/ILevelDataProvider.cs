using UnityEngine;

namespace Code.Gameplay.Levels
{
  public interface ILevelDataProvider
  {
    Vector3 StartPoint { get; }
    Transform StallSpawnParent { get; }
    string CurrentId { get; }

    void SetStartPoint(Vector3 startPoint);
    void SetStallSpawnParent(Transform stallSpawnParent);
    void SetCurrentId(string id);
  }
}
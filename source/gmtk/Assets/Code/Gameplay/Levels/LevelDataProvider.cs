using UnityEngine;

namespace Code.Gameplay.Levels
{
  public class LevelDataProvider : ILevelDataProvider
  {
    public Vector3 StartPoint { get; private set; }
    public Transform StallSpawnParent { get; private set; }
    public string CurrentId { get; private set; } = "first";

    public void SetStartPoint(Vector3 startPoint)
    {
      StartPoint = startPoint;
    }

    public void SetStallSpawnParent(Transform stallSpawnParent)
    {
      StallSpawnParent = stallSpawnParent;
    }

    public void SetCurrentId(string id)
    {
      CurrentId = id;
    }
  }
}
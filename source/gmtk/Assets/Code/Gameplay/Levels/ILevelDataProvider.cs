using UnityEngine;

namespace Code.Gameplay.Levels
{
  public interface ILevelDataProvider
  {
    Transform StartPointParent { get; }
    Transform StallSpawnParent { get; }
    string CurrentId { get; }
    Transform RabbitSpawnParent { get; }
    Transform FoxSpawnParent { get; }
    Transform HoleSpawnParent { get; }
    Transform ConveyorBeltSpawnParent { get; }

    void SetStartPoint(Transform startPoint);
    void SetStallSpawnParent(Transform stallSpawnParent);
    void SetRabbitSpawnParent(Transform rabbitSpawnParent);
    void SetFoxSpawnParent(Transform foxSpawnParent);
    void SetCurrentId(string id);
    void SetHoleSpawnParent(Transform holeSpawnParent);
    void SetConveyorBeltSpawnParent(Transform conveyorBeltSpawnParent);
  }
}
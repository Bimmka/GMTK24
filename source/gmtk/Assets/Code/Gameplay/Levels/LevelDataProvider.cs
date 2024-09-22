using UnityEngine;

namespace Code.Gameplay.Levels
{
  public class LevelDataProvider : ILevelDataProvider
  {
    public Transform StartPointParent{ get; private set; }
    public Transform StallSpawnParent { get; private set; }
    public string CurrentId { get; private set; }
    public Transform RabbitSpawnParent { get; private set; }
    public Transform FoxSpawnParent { get; private set; }
    public Transform HoleSpawnParent { get; private set; }
    public Transform ConveyorBeltSpawnParent { get; private set; }

    public void SetStartPoint(Transform startPoint)
    {
      StartPointParent = startPoint;
    }

    public void SetStallSpawnParent(Transform stallSpawnParent)
    {
      StallSpawnParent = stallSpawnParent;
    }

    public void SetRabbitSpawnParent(Transform rabbitSpawnParent)
    {
      RabbitSpawnParent = rabbitSpawnParent;
    }

    public void SetFoxSpawnParent(Transform foxSpawnParent)
    {
      FoxSpawnParent = foxSpawnParent;
    }
    
    public void SetHoleSpawnParent(Transform holeSpawnParent)
    {
      HoleSpawnParent = holeSpawnParent;
    }

    public void SetConveyorBeltSpawnParent(Transform conveyorBeltSpawnParent)
    {
      ConveyorBeltSpawnParent = conveyorBeltSpawnParent;
    }

    public void SetCurrentId(string id)
    {
      CurrentId = id;
    }
  }
}
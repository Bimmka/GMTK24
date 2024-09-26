namespace Code.Gameplay.Features.TargetCollection
{
  public static class TargetCollectionEntityExtensions
  {
    public static GameEntity RemoveTargetCollectionComponents(this GameEntity entity)
    {
      if (entity.hasTargetBuffer)
        entity.RemoveTargetBuffer();

      if (entity.hasCollectTargetsInterval)
        entity.RemoveCollectTargetsInterval();

      if (entity.hasCollectTargetsTimeLeft)
        entity.RemoveCollectTargetsTimeLeft();

      entity.isReadyToCollectTargets = false;
      
      return entity;
    }
  }
}
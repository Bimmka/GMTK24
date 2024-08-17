using UnityEngine;

namespace Code.Infrastructure.View.Factory
{
  public interface IEntityViewFactory
  {
    EntityBehaviour CreateViewForEntity(GameEntity entity);
    EntityBehaviour CreateViewForEntityFromPrefab(GameEntity entity);
    EntityBehaviour CreateViewForEntityFromPrefab(GameEntity entity, Transform parent);
    EntityBehaviour CreateViewForEntityFromPrefab(GameEntity entity, Quaternion rotation, Transform parent);
  }
}
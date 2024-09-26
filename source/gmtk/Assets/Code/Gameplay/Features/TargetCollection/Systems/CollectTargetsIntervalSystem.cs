using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.TargetCollection.Systems
{
  public class CollectTargetsIntervalSystem : IExecuteSystem
  {
    private readonly ITimeService _time;
    private readonly IGroup<GameEntity> _entities;

    public CollectTargetsIntervalSystem(GameContext game, ITimeService time)
    {
      _time = time;
      _entities = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.TargetBuffer,
          GameMatcher.CollectTargetsInterval,
          GameMatcher.CollectTargetsTimeLeft));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities)
      {
        entity.ReplaceCollectTargetsTimeLeft(entity.CollectTargetsTimeLeft - _time.DeltaTime);

        if (entity.CollectTargetsTimeLeft <= 0)
        {
          entity.isReadyToCollectTargets = true;
          entity.ReplaceCollectTargetsTimeLeft(entity.CollectTargetsInterval);
        }
      }
    }
  }
}
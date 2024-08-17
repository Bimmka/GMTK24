using Code.Gameplay.Features.Rabbits;
using Code.Gameplay.Features.Rabbits.Indexing;
using Entitas;
using Zenject;

namespace Code.Common.EntityIndices
{
  public class GameEntityIndices : IInitializable
  {
    private readonly GameContext _game;
    
    public const string ReplicationTarget = "ReplicationTarget"; 
      
    public GameEntityIndices(GameContext game)
    {
      _game = game;
    }

    public void Initialize()
    {
      _game.AddEntityIndex(new EntityIndex<GameEntity, ReplicationTargetKey>(
        name: ReplicationTarget,
        _game.GetGroup(GameMatcher.AllOf(
          GameMatcher.Rabbit,
          GameMatcher.CanBeChosenForReplication,
          GameMatcher.StallParentIndex,
          GameMatcher.RabbitType,
          GameMatcher.Id)),
        getKey: GetReplicationTargetKey,
        new ReplicationTargetKeyEqualityComparer()));
    }
    
    private ReplicationTargetKey GetReplicationTargetKey(GameEntity entity, IComponent component)
    {
      return new ReplicationTargetKey(
        (component as StallParentIndex)?.Value ?? entity.StallParentIndex,
        (component as RabbitTypeComponent)?.Value ?? entity.RabbitType);
    }
  }
}
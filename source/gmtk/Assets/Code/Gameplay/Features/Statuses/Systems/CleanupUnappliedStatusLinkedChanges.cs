using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Statuses.Systems
{
  public class CleanupUnappliedStatusLinkedChanges : ICleanupSystem
  {
    private readonly IGroup<GameEntity> _statuses;
    private readonly GameContext _game;

    public CleanupUnappliedStatusLinkedChanges(GameContext game)
    {
      _game = game;
      _statuses = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Id,
          GameMatcher.Status,
          GameMatcher.Unapplied,
          GameMatcher.ValidStatus));
    }

    public void Cleanup()
    {
      foreach (GameEntity status in _statuses)
      foreach (GameEntity entity in _game.GetEntitiesWithApplierStatusLink(status.Id))
      {
        entity.isDestructed = true;
      }
    }
  }
}
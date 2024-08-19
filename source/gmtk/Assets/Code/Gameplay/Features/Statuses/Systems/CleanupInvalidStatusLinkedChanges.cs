using Entitas;

namespace Code.Gameplay.Features.Statuses.Systems
{
    public class CleanupInvalidStatusLinkedChanges : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _statuses;
        private readonly GameContext _game;

        public CleanupInvalidStatusLinkedChanges(GameContext game)
        {
            _game = game;
            _statuses = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.Status)
                .NoneOf(GameMatcher.ValidStatus));
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
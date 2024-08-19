using Entitas;

namespace Code.Gameplay.Features.Statuses.Systems
{
    public class UnapplyPoisonStatusSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _statuses;

        public UnapplyPoisonStatusSystem(GameContext game)
        {
            _game = game;
            _statuses = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.PoisonStatus,
                    GameMatcher.TargetId,
                    GameMatcher.Unapplied,
                    GameMatcher.ValidStatus));
        }

        public void Execute()
        {
            foreach (GameEntity status in _statuses)
            {
                GameEntity entity = _game.GetEntityWithId(status.TargetId);
                entity.isDeadByInfection = true;
            }
        }
    }
}
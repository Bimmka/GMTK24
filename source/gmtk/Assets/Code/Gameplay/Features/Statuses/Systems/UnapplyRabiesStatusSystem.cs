using Entitas;

namespace Code.Gameplay.Features.Statuses.Systems
{
    public class UnapplyRabiesStatusSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _statuses;

        public UnapplyRabiesStatusSystem(GameContext game)
        {
            _game = game;
            _statuses = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.RabiesStatus,
                    GameMatcher.TargetId,
                    GameMatcher.Unapplied));
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
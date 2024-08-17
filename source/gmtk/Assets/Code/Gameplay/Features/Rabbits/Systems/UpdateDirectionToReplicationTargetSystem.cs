using Entitas;

namespace Code.Gameplay.Features.Rabbits.Systems
{
    public class UpdateDirectionToReplicationTargetSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _movers;

        public UpdateDirectionToReplicationTargetSystem(GameContext game)
        {
            _game = game;
            _movers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.ReplicationTarget,
                    GameMatcher.MoveDirection,
                    GameMatcher.MovementAvailable,
                    GameMatcher.ReplicationPhase));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _movers)
            {
                GameEntity target = _game.GetEntityWithId(mover.ReplicationTarget);

                mover.ReplaceMoveDirection((target.WorldPosition - mover.WorldPosition).normalized);
            }
        }
    }
}
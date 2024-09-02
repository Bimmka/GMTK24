using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Replication.Systems
{
    public class SetWaitingReplicationTargetSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _rabbits;

        public SetWaitingReplicationTargetSystem(GameContext game)
        {
            _game = game;
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.ReplicationTarget,
                    GameMatcher.WantToReplicate,
                    GameMatcher.ReplicationAvailable,
                    GameMatcher.ValidReplicationTarget));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                GameEntity target = _game.GetEntityWithId(rabbit.ReplicationTarget);

                rabbit.isWaitingReplicationTarget = target.isDragging;
            }
        }
    }
}
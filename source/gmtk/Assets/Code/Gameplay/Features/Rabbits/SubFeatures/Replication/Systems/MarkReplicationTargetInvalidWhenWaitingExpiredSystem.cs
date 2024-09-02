using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Replication.Systems
{
    public class MarkReplicationTargetInvalidWhenWaitingExpiredSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _rabbits;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public MarkReplicationTargetInvalidWhenWaitingExpiredSystem(GameContext game)
        {
            _game = game;
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ReplicationTarget,
                    GameMatcher.ReplicationExpired,
                    GameMatcher.ReplicationAvailable,
                    GameMatcher.ValidReplicationTarget,
                    GameMatcher.Alive,
                    GameMatcher.Rabbit,
                    GameMatcher.WantToReplicate));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits.GetEntities(_buffer))
            {
                rabbit.isValidReplicationTarget = false;
                rabbit.isInvalidReplicationTarget = true;

                GameEntity target = _game.GetEntityWithId(rabbit.ReplicationTarget);
                target.isValidReplicationTarget = false;
                target.isInvalidReplicationTarget = true;
            }
        }
    }
}
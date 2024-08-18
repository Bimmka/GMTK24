using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Replication.Systems
{
    public class RemoveReplicationTargetComponentWhenWaitingExpiredSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _rabbits;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public RemoveReplicationTargetComponentWhenWaitingExpiredSystem(GameContext game)
        {
            _game = game;
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ReplicationTarget,
                    GameMatcher.ReplicationExpired));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits.GetEntities(_buffer))
            {
                rabbit.isInvalidReplicationTarget = true;
                rabbit.RemoveReplicationTarget();
            }
        }
    }
}
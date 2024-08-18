using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Replication.Systems
{
    public class CleanupReplicationExpireMarkersSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _rabbits;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public CleanupReplicationExpireMarkersSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.ReplicationExpired));
        }

        public void Cleanup()
        {
            foreach (GameEntity rabbit in _rabbits.GetEntities(_buffer))
            {
                rabbit.isReplicationExpired = false;
            }
        }
    }
}
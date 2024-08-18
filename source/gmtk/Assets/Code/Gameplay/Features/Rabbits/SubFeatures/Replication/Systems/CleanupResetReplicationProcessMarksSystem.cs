using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Replication.Systems
{
    public class CleanupResetReplicationProcessMarkersSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _rabbits;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public CleanupResetReplicationProcessMarkersSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.CleanupResetReplicationMarkers)
                .AnyOf(
                    GameMatcher.InvalidReplicationTarget,
                    GameMatcher.ResetReplicationProcess));
        }

        public void Cleanup()
        {
            foreach (GameEntity rabbit in _rabbits.GetEntities(_buffer))
            {
                rabbit.isInvalidReplicationTarget = false;
                rabbit.isResetReplicationProcess = false;
                rabbit.isCleanupResetReplicationMarkers = false;
            }
        }
    }
}
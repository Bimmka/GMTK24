using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Replication.Systems
{
    public class ResetReplicationProcessMarkersForTargetsSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _rabbits;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public ResetReplicationProcessMarkersForTargetsSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ChosenForReplicationBy,
                    GameMatcher.Rabbit)
                .AnyOf(
                    GameMatcher.InvalidReplicationTarget,
                    GameMatcher.ResetReplicationProcess));
        }

        public void Cleanup()
        {
            foreach (GameEntity rabbit in _rabbits.GetEntities(_buffer))
            {
                rabbit.isCanBeChosenForReplication = true;
                rabbit.isCanStartReplication = true;
                rabbit.isWaitingForNextReplicationUp = true;
                rabbit.isChosenForReplication = false;
                rabbit.RemoveChosenForReplicationBy();

                rabbit.isCleanupResetReplicationMarkers = true;
            }
        }
    }
}
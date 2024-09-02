using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Replication.Systems
{
    public class CheckReplicationTargetForValidByStallIndexSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _replicators;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public CheckReplicationTargetForValidByStallIndexSystem(GameContext game)
        {
            _game = game;
            _replicators = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ReplicationTarget,
                    GameMatcher.StallParentIndex,
                    GameMatcher.ReplicationAvailable,
                    GameMatcher.Alive,
                    GameMatcher.WantToReplicate,
                    GameMatcher.ValidReplicationTarget));
        }

        public void Execute()
        {
            foreach (GameEntity replicator in _replicators.GetEntities(_buffer))
            {
                GameEntity target = _game.GetEntityWithId(replicator.ReplicationTarget);

                if (target.hasStallParentIndex == false || target.StallParentIndex != replicator.StallParentIndex)
                {
                    replicator.isInvalidReplicationTarget = true;
                    replicator.isValidReplicationTarget = false;

                    target.isInvalidReplicationTarget = true;
                    target.isValidReplicationTarget = false;
                }
            }
        }
    }
}
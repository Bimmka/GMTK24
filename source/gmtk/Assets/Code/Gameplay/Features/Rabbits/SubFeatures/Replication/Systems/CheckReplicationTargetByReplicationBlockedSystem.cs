using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Replication.Systems
{
    public class CheckReplicationTargetByReplicationBlockedSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _replicators;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public CheckReplicationTargetByReplicationBlockedSystem(GameContext game)
        {
            _game = game;
            _replicators = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ReplicationTarget,
                    GameMatcher.Alive,
                    GameMatcher.Rabbit,
                    GameMatcher.WantToReplicate,
                    GameMatcher.ValidReplicationTarget));
        }

        public void Execute()
        {
            foreach (GameEntity replicator in _replicators.GetEntities(_buffer))
            {
                GameEntity target = _game.GetEntityWithId(replicator.ReplicationTarget);
                
                if (target.isReplicationBlocked == false)
                    continue;

                replicator.isInvalidReplicationTarget = true;
                replicator.isValidReplicationTarget = false;
                
                target.isInvalidReplicationTarget = true;
                target.isValidReplicationTarget = false;
            }
        }
    }
}
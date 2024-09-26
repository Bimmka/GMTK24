using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Replication.Systems
{
    public class CheckReplicationTargetForValidByConveyoringSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _replicators;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public CheckReplicationTargetForValidByConveyoringSystem(GameContext game)
        {
            _game = game;
            _replicators = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ReplicationTarget,
                    GameMatcher.WantToReplicate,
                    GameMatcher.ReplicationAvailable,
                    GameMatcher.Alive,
                    GameMatcher.Rabbit,
                    GameMatcher.ValidReplicationTarget));
        }

        public void Execute()
        {
            foreach (GameEntity replicator in _replicators.GetEntities(_buffer))
            {
                GameEntity target = _game.GetEntityWithId(replicator.ReplicationTarget);
                
                if (target.isOnConveyorBelt == false)
                    continue;

                replicator.isValidReplicationTarget = false;
                replicator.isInvalidReplicationTarget = true;

                target.isValidReplicationTarget = false;
                target.isInvalidReplicationTarget = true;
            }
        }
    }
}
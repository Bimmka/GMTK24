using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Replication.Systems
{
    public class RemoveReplicationTargetComponentWithoutPositionSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _replicators;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public RemoveReplicationTargetComponentWithoutPositionSystem(GameContext game)
        {
            _game = game;
            _replicators = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ReplicationTarget,
                    GameMatcher.WantToReplicate,
                    GameMatcher.ReplicationAvailable,
                    GameMatcher.Alive,
                    GameMatcher.Rabbit));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _replicators.GetEntities(_buffer))
            {
                GameEntity target = _game.GetEntityWithId(mover.ReplicationTarget);
                
                if (target.hasWorldPosition)
                    continue;

                mover.isInvalidReplicationTarget = true;
                mover.RemoveReplicationTarget();
                
                target.isResetReplicationProcess = true;
            }
        }
    }
}
using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.Systems
{
    public class RemoveReplicationTargetComponentWithoutPositionSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _movers;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public RemoveReplicationTargetComponentWithoutPositionSystem(GameContext game)
        {
            _game = game;
            _movers = game.GetGroup(GameMatcher.ReplicationTarget);
        }

        public void Execute()
        {
            foreach (GameEntity mover in _movers.GetEntities(_buffer))
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
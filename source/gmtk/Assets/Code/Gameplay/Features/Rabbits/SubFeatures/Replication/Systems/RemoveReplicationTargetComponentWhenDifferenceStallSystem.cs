using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Replication.Systems
{
    public class RemoveReplicationTargetComponentWhenDifferenceStallSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _movers;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public RemoveReplicationTargetComponentWhenDifferenceStallSystem(GameContext game)
        {
            _game = game;
            _movers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ReplicationTarget,
                    GameMatcher.StallParentIndex));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _movers.GetEntities(_buffer))
            {
                GameEntity target = _game.GetEntityWithId(mover.ReplicationTarget);

                if (target.hasStallParentIndex == false || target.StallParentIndex != mover.StallParentIndex)
                {
                    mover.isInvalidReplicationTarget = true;
                    target.isResetReplicationProcess = true;
                    mover.RemoveReplicationTarget();
                }
            }
        }
    }
}
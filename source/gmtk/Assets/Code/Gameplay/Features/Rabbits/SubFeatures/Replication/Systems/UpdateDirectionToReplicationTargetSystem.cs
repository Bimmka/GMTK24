using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Replication.Systems
{
    public class UpdateDirectionToReplicationTargetSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _movers;

        public UpdateDirectionToReplicationTargetSystem(GameContext game)
        {
            _game = game;
            _movers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.ReplicationTarget,
                    GameMatcher.MovementAvailable,
                    GameMatcher.WantToReplicate,
                    GameMatcher.ReplicationAvailable,
                    GameMatcher.ValidReplicationTarget,
                    GameMatcher.MovingToReplicationTarget,
                    GameMatcher.Alive));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _movers)
            {
                GameEntity target = _game.GetEntityWithId(mover.ReplicationTarget);

                if (mover.isWaitingReplicationTarget) 
                    mover.ReplaceMoveDirection(Vector2.zero);
                else
                    mover.ReplaceMoveDirection((target.WorldPosition - mover.WorldPosition).normalized);
            }
        }
    }
}
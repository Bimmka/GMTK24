using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Replication.Systems
{
    public class MarkNearReplicationTargetSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _rabbits;

        public MarkNearReplicationTargetSystem(GameContext game)
        {
            _game = game;
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.ReplicationTarget,
                    GameMatcher.WorldPosition,
                    GameMatcher.WantToReplicate,
                    GameMatcher.ReplicationAvailable,
                    GameMatcher.ValidReplicationTarget,
                    GameMatcher.Alive)
                .NoneOf(GameMatcher.Dragging));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                GameEntity target = _game.GetEntityWithId(rabbit.ReplicationTarget);

                rabbit.isNearReplicationTarget = (Vector3.SqrMagnitude(target.WorldPosition - rabbit.WorldPosition) <= 0.5f
                                                  && rabbit.isWaitingReplicationTarget == false);
            }
        }
    }
}
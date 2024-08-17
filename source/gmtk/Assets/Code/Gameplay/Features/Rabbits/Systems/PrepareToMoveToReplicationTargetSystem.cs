using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.Systems
{
    public class PrepareToMoveToReplicationTargetSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public PrepareToMoveToReplicationTargetSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.ReplicationTarget,
                    GameMatcher.MovementAvailable,
                    GameMatcher.ActivityFree)
                .NoneOf(GameMatcher.ReplicationPhase));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits.GetEntities(_buffer))
            {
                rabbit.isWaitingForMoving = false;
                rabbit.isMovingUp = false;

                rabbit.isReplicationPhase = true;
                rabbit.isMovingPhase = false;
            }
        }
    }
}
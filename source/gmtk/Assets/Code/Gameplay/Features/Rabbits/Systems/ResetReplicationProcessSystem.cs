using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.Systems
{
    public class ResetReplicationProcessSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public ResetReplicationProcessSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AnyOf(
                    GameMatcher.InvalidReplicationTarget,
                    GameMatcher.ResetReplicationProcess));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits.GetEntities(_buffer))
            {
                rabbit.isWaitingForMoving = true;
                rabbit.isCanBeChosenForReplication = true;
                rabbit.isWaitingForNextReplicationUp = true;
                rabbit.isChosenForReplication = false;
                rabbit.isInvalidReplicationTarget = false;
                rabbit.isResetReplicationProcess = false;
                rabbit.isNearReplicationTarget = false;

                if (rabbit.hasChosenForReplicationBy)
                    rabbit.RemoveChosenForReplicationBy();

                rabbit.isReplicationPhase = false;
                rabbit.isMovingPhase = true;
            }
        }
    }
}
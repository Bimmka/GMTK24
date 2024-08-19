using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Foxes.Systems
{
    public class StopMovingToReachedTargetPointSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _foxes;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public StopMovingToReachedTargetPointSystem(GameContext game)
        {
            _foxes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fox,
                    GameMatcher.MovingToRandomPoint,
                    GameMatcher.Alive,
                    GameMatcher.TargetPointReached,
                    GameMatcher.TargetPoint,
                    GameMatcher.MovingInterval,
                    GameMatcher.TimeLeftForMoving,
                    GameMatcher.FoxAnimator));
        }

        public void Execute()
        {
            foreach (GameEntity fox in _foxes.GetEntities(_buffer))
            {
                fox.isMovingToRandomPoint = false;
                fox.isWaitingForMoving = true;
                fox.isMoving = false;
                
                fox.ReplaceTimeLeftForMoving(fox.MovingInterval);
                fox.RemoveTargetPoint();

                fox.FoxAnimator.StopMove();
            }
        }
    }
}
using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.StupidMove.Systems
{
    public class CleanupMoveFinishedSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _rabbits;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public CleanupMoveFinishedSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.TargetPointReached,
                    GameMatcher.MovingFinished,
                    GameMatcher.CleanupMovingFinished));
        }

        public void Cleanup()
        {
            foreach (GameEntity rabbit in _rabbits.GetEntities(_buffer))
            {
                rabbit.isTargetPointReached = false;
                rabbit.isMovingFinished = false;
                rabbit.isCleanupMovingFinished = false;
            }
        }
    }
}
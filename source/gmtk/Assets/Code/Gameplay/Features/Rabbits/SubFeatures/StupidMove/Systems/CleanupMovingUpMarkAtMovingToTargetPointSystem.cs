using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.StupidMove.Systems
{
    public class CleanupMovingUpMarkAtMovingToTargetPointSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _rabbits;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(16);

        public CleanupMovingUpMarkAtMovingToTargetPointSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.MovingUp,
                    GameMatcher.Alive,
                    GameMatcher.Moving, 
                    GameMatcher.TargetPoint));
        }

        public void Cleanup()
        {
            foreach (GameEntity rabbit in _rabbits.GetEntities(_buffer))
            {
                rabbit.isMovingUp = false;
            }
        }
    }
}
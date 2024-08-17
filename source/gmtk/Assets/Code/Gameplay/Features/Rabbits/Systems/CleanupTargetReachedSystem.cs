using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.Systems
{
    public class CleanupTargetReachedSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _rabbits;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public CleanupTargetReachedSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.TargetPointReached,
                    GameMatcher.TargetPoint));
        }

        public void Cleanup()
        {
            foreach (GameEntity rabbit in _rabbits.GetEntities(_buffer))
            {
                rabbit.isTargetPointReached = false;
                rabbit.RemoveTargetPoint();
                rabbit.isMoving = false;
            }
        }
    }
}
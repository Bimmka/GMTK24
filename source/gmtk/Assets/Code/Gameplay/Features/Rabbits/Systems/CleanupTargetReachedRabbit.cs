using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.Systems
{
    public class CleanupTargetReachedRabbit : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _rabbits;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public CleanupTargetReachedRabbit(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.TargetReached,
                    GameMatcher.TargetPoint)
                .NoneOf(GameMatcher.Moving));
        }

        public void Cleanup()
        {
            foreach (GameEntity rabbit in _rabbits.GetEntities(_buffer))
            {
                rabbit.isTargetReached = false;
                rabbit.RemoveTargetPoint();
            }
        }
    }
}
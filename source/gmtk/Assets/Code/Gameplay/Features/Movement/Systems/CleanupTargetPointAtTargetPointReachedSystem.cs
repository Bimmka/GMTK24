using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class CleanupTargetPointAtTargetPointReachedSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _reached;
        private readonly List<GameEntity> _buffer = new(32);

        public CleanupTargetPointAtTargetPointReachedSystem(GameContext game)
        {
            _reached = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TargetPoint,
                    GameMatcher.TargetPointReached));
        }

        public void Cleanup()
        {
            foreach (GameEntity reached in _reached.GetEntities(_buffer))
            {
                reached.RemoveTargetPoint();
                reached.isTargetPointReached = false;
            }
        }
    }
}
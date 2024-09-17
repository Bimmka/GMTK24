using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Foxes.Systems
{
    public class CleanupMarkHuntStartedSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _foxes;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(8);

        public CleanupMarkHuntStartedSystem(GameContext game)
        {
            _foxes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fox,
                    GameMatcher.Alive,
                    GameMatcher.HuntStarted));
        }

        public void Cleanup()
        {
            foreach (GameEntity fox in _foxes.GetEntities(_buffer))
            {
                fox.isHuntStarted = false;
            }
        }
    }
}
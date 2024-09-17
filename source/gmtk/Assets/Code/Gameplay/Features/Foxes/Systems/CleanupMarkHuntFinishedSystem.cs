using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Foxes.Systems
{
    public class CleanupMarkHuntFinishedSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _foxes;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(8);

        public CleanupMarkHuntFinishedSystem(GameContext game)
        {
            _foxes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fox,
                    GameMatcher.Alive,
                    GameMatcher.HuntFinished));
        }

        public void Cleanup()
        {
            foreach (GameEntity fox in _foxes.GetEntities(_buffer))
            {
                fox.isHuntFinished = false;
            }
        }
    }
}
using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Foxes.Systems
{
    public class CleanupHuntTargetWhenHuntFinished : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _foxes;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(8);

        public CleanupHuntTargetWhenHuntFinished(GameContext game)
        {
            _foxes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fox,
                    GameMatcher.HuntTarget,
                    GameMatcher.HuntFinished));
        }

        public void Cleanup()
        {
            foreach (GameEntity fox in _foxes.GetEntities(_buffer))
            {
                fox.RemoveHuntTarget();
            }
        }
    }
}
using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Foxes.Systems
{
    public class CleanupHuntHuntSoundWhenHuntFinished : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _foxes;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(8);

        public CleanupHuntHuntSoundWhenHuntFinished(GameContext game)
        {
            _foxes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fox,
                    GameMatcher.AttachedSound,
                    GameMatcher.HuntFinished));
        }

        public void Cleanup()
        {
            foreach (GameEntity fox in _foxes.GetEntities(_buffer))
            {
                fox.AttachedSound.Reset();
                fox.RemoveAttachedSound();
            }
        }
    }
}
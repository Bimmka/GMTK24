using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Death.Systems
{
    public class CleanupSoundsFromDeadSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _sounds;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public CleanupSoundsFromDeadSystem(GameContext game)
        {
            _sounds = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.HuntSoundElement,
                    GameMatcher.Dead));
        }

        public void Cleanup()
        {
            foreach (GameEntity sound in _sounds.GetEntities(_buffer))
            {
                if (sound.HuntSoundElement != null)
                    sound.HuntSoundElement.Reset();

                sound.RemoveHuntSoundElement();
            }
        }
    }
}
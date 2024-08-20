using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Dead.Systems
{
    public class RemoveSoundsSystem : ITearDownSystem
    {
        private readonly IGroup<GameEntity> _sounds;

        public RemoveSoundsSystem(GameContext game)
        {
            _sounds = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.HuntSoundElement));
        }

        public void TearDown()
        {
            foreach (GameEntity sound in _sounds)
            {
                if (sound.HuntSoundElement != null)
                    sound.HuntSoundElement.Reset();
            }
        }
    }
}
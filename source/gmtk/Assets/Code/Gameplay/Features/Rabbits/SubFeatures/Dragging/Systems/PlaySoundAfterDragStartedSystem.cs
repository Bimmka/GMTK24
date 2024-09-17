using Code.Gameplay.Sounds.Config;
using Code.Gameplay.Sounds.Service;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Dragging.Systems
{
    public class PlaySoundAfterDragStartedSystem : IExecuteSystem
    {
        private readonly IAudioService _audioService;
        private readonly IGroup<GameEntity> _rabbits;

        public PlaySoundAfterDragStartedSystem(GameContext game, IAudioService audioService)
        {
            _audioService = audioService;
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.DragStarted));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                rabbit.ReplaceHuntSoundElement(_audioService.PlayAudio(SoundType.Dragging));
            }
        }
    }
}
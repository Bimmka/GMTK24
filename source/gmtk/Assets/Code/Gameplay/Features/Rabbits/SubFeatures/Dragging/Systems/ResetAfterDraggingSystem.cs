using System.Collections.Generic;
using Code.Gameplay.Sounds.Config;
using Code.Gameplay.Sounds.Service;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Dragging.Systems
{
    public class PlaySoundAfterDragFinishedSystem : IExecuteSystem
    {
        private readonly IAudioService _audioService;
        private readonly IGroup<GameEntity> _rabbits;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public PlaySoundAfterDragFinishedSystem(GameContext game, IAudioService audioService)
        {
            _audioService = audioService;
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.DragFinished));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits.GetEntities(_buffer))
            {
                _audioService.PlayAudio(SoundType.RabbitLand);
            }
        }
    }
}
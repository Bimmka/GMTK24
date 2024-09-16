using System.Collections.Generic;
using Code.Gameplay.Sounds.Config;
using Code.Gameplay.Sounds.Service;
using Entitas;

namespace Code.Gameplay.Features.Selection.SubFeatures.Release.Systems
{
    public class ReleaseSelectedSystem : IExecuteSystem
    {
        private readonly IAudioService _audioService;
        private readonly IGroup<GameEntity> _selected;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(16);

        public ReleaseSelectedSystem(GameContext game, IAudioService audioService)
        {
            _audioService = audioService;
            _selected = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Selected,
                    GameMatcher.ReleaseFromDragUp,
                    GameMatcher.SavedPositionBeforeDrag,
                    GameMatcher.Dragging));
        }

        public void Execute()
        {
            foreach (GameEntity selected in _selected.GetEntities(_buffer))
            {
                selected.isMovingToAfterDragPosition = true;
                selected.isDragging = false;
                selected.ReplaceAfterDragPosition(selected.SavedPositionBeforeDrag);

                _audioService.PlayAudio(SoundType.RabbitDragRelease);
            }
        }
    }
}
using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Dragging.Systems
{
    public class CleanupDragFinishedMarkSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _selected;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public CleanupDragFinishedMarkSystem(GameContext game)
        {
            _selected = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.DragFinished,
                GameMatcher.Rabbit));
        }

        public void Cleanup()
        {
            foreach (GameEntity selected in _selected.GetEntities(_buffer))
            {
                selected.isDragFinished = false;
            }
        }
    }
}
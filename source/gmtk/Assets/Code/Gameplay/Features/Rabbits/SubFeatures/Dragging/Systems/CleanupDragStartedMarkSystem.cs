using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Dragging.Systems
{
    public class CleanupDragStartedMarkSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _selected;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public CleanupDragStartedMarkSystem(GameContext game)
        {
            _selected = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.DragStarted,
                GameMatcher.Dragging,
                GameMatcher.Rabbit));
        }

        public void Cleanup()
        {
            foreach (GameEntity selected in _selected.GetEntities(_buffer))
            {
                selected.isDragStarted = false;
            }
        }
    }
}
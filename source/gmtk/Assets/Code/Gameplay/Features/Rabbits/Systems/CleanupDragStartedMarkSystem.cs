using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.Systems
{
    public class CleanupDragStartedMarkSystem : ICleanupSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _selected;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public CleanupDragStartedMarkSystem(GameContext game)
        {
            _game = game;
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
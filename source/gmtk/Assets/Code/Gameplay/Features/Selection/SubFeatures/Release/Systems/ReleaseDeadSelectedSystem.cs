using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Selection.SubFeatures.Release.Systems
{
    public class ReleaseDeadSelectedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _selected;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(16);

        public ReleaseDeadSelectedSystem(GameContext game)
        {
            _selected = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Dragging,
                    GameMatcher.Dead));
        }

        public void Execute()
        {
            foreach (GameEntity selected in _selected.GetEntities(_buffer))
            {
                selected.isDragging = false;
            }
        }
    }
}
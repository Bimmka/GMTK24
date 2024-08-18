using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Selection.Systems
{
    public class RemoveUnselectMarkFromSelectionSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _selections;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(1);

        public RemoveUnselectMarkFromSelectionSystem(GameContext game)
        {
            _selections = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Selection,
                GameMatcher.CleanupUnselectMark,
                GameMatcher.UnselectSelectedEntities));
        }

        public void Cleanup()
        {
            foreach (GameEntity selection in _selections.GetEntities(_buffer))
            {
                selection.isUnselectSelectedEntities = false;
                selection.isCleanupUnselectMark = false;
            }
        }
    }
}
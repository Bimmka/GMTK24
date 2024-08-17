using Entitas;

namespace Code.Gameplay.Features.Selection.Systems
{
    public class RemoveUnselectMarkFromSelectionSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _selections;

        public RemoveUnselectMarkFromSelectionSystem(GameContext game)
        {
            _selections = game.GetGroup(GameMatcher.AllOf(GameMatcher.Selection));
        }

        public void Cleanup()
        {
            foreach (GameEntity selection in _selections)
            {
                selection.isUnselectSelectedEntities = false;
            }
        }
    }
}
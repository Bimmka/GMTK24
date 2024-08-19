using Entitas;

namespace Code.Gameplay.Features.Selection.Systems
{
    public class ClearSelectedEntitiesWhenUnselectSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _selections;

        public ClearSelectedEntitiesWhenUnselectSystem(GameContext game)
        {
            _game = game;
            _selections = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.SelectedEntities,
                    GameMatcher.UnselectSelectedEntities));
        }

        public void Execute()
        {
            foreach (GameEntity selection in _selections)
            {
                foreach (int entityId in selection.SelectedEntities)
                {
                    GameEntity selectedEntity = _game.GetEntityWithId(entityId);
                    selectedEntity.isSelected = false;
                }

                selection.SelectedEntities.Clear();
                selection.isCleanupUnselectMark = true;
            }
        }
    }
}
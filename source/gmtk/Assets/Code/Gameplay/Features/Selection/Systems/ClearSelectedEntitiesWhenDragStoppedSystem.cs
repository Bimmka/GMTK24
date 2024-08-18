using Entitas;

namespace Code.Gameplay.Features.Selection.Systems
{
    public class ClearSelectedEntitiesWhenDragStoppedSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _selections;

        public ClearSelectedEntitiesWhenDragStoppedSystem(GameContext game)
        {
            _game = game;
            _selections = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.SelectedEntities,
                    GameMatcher.HasSelections,
                    GameMatcher.DragStopped));
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
            }
        }
    }
}
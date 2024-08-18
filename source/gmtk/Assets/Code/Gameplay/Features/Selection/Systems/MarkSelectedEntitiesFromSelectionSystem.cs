using Entitas;

namespace Code.Gameplay.Features.Selection.Systems
{
    public class MarkSelectedEntitiesFromSelectionSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _selections;

        public MarkSelectedEntitiesFromSelectionSystem(GameContext game)
        {
            _game = game;

            _selections = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Selection,
                    GameMatcher.HasSelections));
        }

        public void Execute()
        {
            foreach (GameEntity selection in _selections)
            {
                foreach (int entityId in selection.SelectedEntities)
                {
                    GameEntity selectedEntity = _game.GetEntityWithId(entityId);

                    selectedEntity.isSelected = true;
                }
            }
        }
    }
}
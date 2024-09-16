using Entitas;

namespace Code.Gameplay.Features.Selection.Systems
{
    public class UnselectEntitiesWhenReleaseSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _selections;

        public UnselectEntitiesWhenReleaseSystem(GameContext game)
        {
            _game = game;
            _selections = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Dragging,
                    GameMatcher.Selection,
                    GameMatcher.EntitiesForReleaseQueue,
                    GameMatcher.SelectedEntities));
        }

        public void Execute()
        {
            foreach (GameEntity selection in _selections)
            {
                foreach (int entityId in selection.EntitiesForReleaseQueue)
                {
                    GameEntity selectedEntity = _game.GetEntityWithId(entityId);
                        
                    if (selectedEntity != null)
                        selectedEntity.isSelected = false;
                }
            }
        }
    }
}
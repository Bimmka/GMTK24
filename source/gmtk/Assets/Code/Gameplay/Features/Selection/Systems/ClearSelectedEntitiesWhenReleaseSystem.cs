using Entitas;

namespace Code.Gameplay.Features.Selection.Systems
{
    public class ClearSelectedEntitiesWhenReleaseSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _selections;

        public ClearSelectedEntitiesWhenReleaseSystem(GameContext game)
        {
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
                while (selection.EntitiesForReleaseQueue.Count > 0)
                {
                    var entityId = selection.EntitiesForReleaseQueue.Dequeue();
                    selection.SelectedEntities.Remove(entityId);
                }
                
                selection.EntitiesForReleaseQueue.Clear();
            }
        }
    }
}
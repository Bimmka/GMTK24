using Entitas;

namespace Code.Gameplay.Features.Selection.Systems
{
    public class AddSelectedEntitiesFromQueueSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _selections;

        public AddSelectedEntitiesFromQueueSystem(GameContext game)
        {
            _selections = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.SelectedEntities,
                    GameMatcher.EntitiesForSelectionQueue));
        }

        public void Execute()
        {
            foreach (GameEntity selection in _selections)
            {
                while (selection.EntitiesForSelectionQueue.Count > 0)
                {
                    var entityId = selection.EntitiesForSelectionQueue.Dequeue();
                    
                    if (selection.SelectedEntities.Contains(entityId) == false)
                        selection.SelectedEntities.Add(entityId);
                }
                
                selection.EntitiesForSelectionQueue.Clear();
            }
        }
    }
}
using Entitas;

namespace Code.Gameplay.Features.Selection.SubFeatures.Release.Systems
{
    public class CollectDeadSelectedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _selected;
        private readonly IGroup<GameEntity> _selections;

        public CollectDeadSelectedSystem(GameContext game)
        {
            _selected = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Dead,
                    GameMatcher.Dragging,
                    GameMatcher.Id));

            _selections = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Selection,
                    GameMatcher.EntitiesForReleaseQueue,
                    GameMatcher.Dragging,
                    GameMatcher.HasSelections));
        }

        public void Execute()
        {
            foreach (var selection in _selections)
            {
                foreach (GameEntity selected in _selected)
                {
                    if (selection.EntitiesForReleaseQueue.Contains(selected.Id) == false)
                        selection.EntitiesForReleaseQueue.Enqueue(selected.Id);
                }   
            }
        }
    }
}
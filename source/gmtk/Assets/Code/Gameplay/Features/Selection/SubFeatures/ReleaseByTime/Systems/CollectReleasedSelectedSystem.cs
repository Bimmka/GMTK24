using Entitas;

namespace Code.Gameplay.Features.Selection.SubFeatures.ReleaseByTime
{
    public class CollectReleasedSelectedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _selected;
        private readonly IGroup<GameEntity> _selections;

        public CollectReleasedSelectedSystem(GameContext game)
        {
            _selected = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ReleaseFromDragUp,
                    GameMatcher.Dragging,
                    GameMatcher.Id,
                    GameMatcher.DraggingState));

            _selections = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Selection,
                    GameMatcher.EntitiesForReleaseQueue));
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
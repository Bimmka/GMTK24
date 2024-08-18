using Entitas;

namespace Code.Gameplay.Features.Selection.SubFeatures.ReleaseByTime
{
    public class RemoveReleaseUpMarkSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _selected;

        public RemoveReleaseUpMarkSystem(GameContext game)
        {
            _selected = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Selected));
        }

        public void Execute()
        {
            foreach (GameEntity selected in _selected)
            {
                selected.isReleaseFromDragUp = false;
            }
        }
    }
}
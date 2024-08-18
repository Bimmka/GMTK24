using Entitas;

namespace Code.Gameplay.Features.Selection.Systems
{
    public class RefreshHasSelectedMarkSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _selections;

        public RefreshHasSelectedMarkSystem(GameContext game)
        {
            _selections = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Selection,
                    GameMatcher.SelectedEntities));
        }

        public void Execute()
        {
            foreach (GameEntity selection in _selections)
            {
                selection.isHasSelections = selection.SelectedEntities.Count > 0;
            }
        }
    }
}
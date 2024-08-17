using Entitas;

namespace Code.Gameplay.Features.Selection.SubFeatures.SelectionCenter.Systems
{
    public class UpdateSelectionCenterPositionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _selections;
        private readonly IGroup<InputEntity> _inputs;

        public UpdateSelectionCenterPositionSystem(GameContext game, InputContext inputContext)
        {
            _selections = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.SelectCenterPosition,
                    GameMatcher.Dragging));

            _inputs = inputContext.GetGroup(InputMatcher
                .AllOf(
                    InputMatcher.Input,
                    InputMatcher.WorldMousePosition,
                    InputMatcher.MousePressed));
        }

        public void Execute()
        {
            foreach (InputEntity input in _inputs)
            {
                foreach (GameEntity selection in _selections)
                {
                    selection.ReplaceSelectCenterPosition(input.WorldMousePosition);
                }
            }
        }
    }
}
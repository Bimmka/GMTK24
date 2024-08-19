using Entitas;

namespace Code.Gameplay.Features.Selection.Systems
{
    public class DisplayMultipleSelectionAreaSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _selectionWindows;
        private readonly IGroup<GameEntity> _selections;
        private readonly IGroup<InputEntity> _inputs;

        public DisplayMultipleSelectionAreaSystem(GameContext game, InputContext input)
        {
            _selectionWindows = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.MultipleSelectionWindow));

            _selections = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Selection,
                    GameMatcher.WaitingMouseDragFinish));
            
            _inputs = input.GetGroup(InputMatcher
                .AllOf(
                    InputMatcher.Input,
                    InputMatcher.MousePressed,
                    InputMatcher.StartMouseDownWorldPosition,
                    InputMatcher.WorldMousePosition,
                    InputMatcher.Dragging));
        }

        public void Execute()
        {
            foreach (InputEntity input in _inputs)
            {
                foreach (GameEntity selection in _selections)
                {
                    foreach (GameEntity window in _selectionWindows)
                    {
                        window.MultipleSelectionWindow.Display(input.StartMouseDownScreenPosition, input.ScreenMousePosition);
                    }
                }
            }
        }
    }
}
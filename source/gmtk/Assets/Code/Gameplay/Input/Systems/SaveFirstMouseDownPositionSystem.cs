using Entitas;

namespace Code.Gameplay.Input.Systems
{
    public class SaveFirstMouseDownPositionSystem : IExecuteSystem
    {
        private readonly IGroup<InputEntity> _inputs;
        
        public SaveFirstMouseDownPositionSystem(InputContext meta)
        {
            _inputs = meta.GetGroup(InputMatcher
                .AllOf(
                    InputMatcher.Input,
                    InputMatcher.MouseDown,
                    InputMatcher.WorldMousePosition,
                    InputMatcher.ScreenMousePosition));
        }

        public void Execute()
        {
            foreach (InputEntity input in _inputs)
            {
                input.ReplaceStartMouseDownScreenPosition(input.ScreenMousePosition);
                input.ReplaceStartMouseDownWorldPosition(input.WorldMousePosition);
            }
        }
    }
}
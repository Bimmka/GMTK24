using Entitas;

namespace Code.Gameplay.Input.Systems
{
    public class MarkDraggingSystem : IExecuteSystem
    {
        private readonly IGroup<InputEntity> _inputs;
        
        public MarkDraggingSystem(InputContext meta)
        {
            _inputs = meta.GetGroup(InputMatcher
                .AllOf(
                    InputMatcher.Input,
                    InputMatcher.WorldMousePosition,
                    InputMatcher.StartMouseDownWorldPosition));
        }

        public void Execute()
        {
            foreach (InputEntity input in _inputs)
            {
                if (input.isMousePressed)
                    input.isDraging = input.WorldMousePosition != input.StartMouseDownWorldPosition;
                else
                    input.isDraging = false;
            }
        }
    }
}
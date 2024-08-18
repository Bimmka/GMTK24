using Entitas;

namespace Code.Gameplay.Input.Systems
{
    public class MarkWasDraggingSystem : IExecuteSystem
    {
        private readonly IGroup<InputEntity> _inputs;
        
        public MarkWasDraggingSystem(InputContext meta)
        {
            _inputs = meta.GetGroup(InputMatcher
                .AllOf(
                    InputMatcher.Input,
                    InputMatcher.Dragging,
                    InputMatcher.MouseUp));
        }

        public void Execute()
        {
            foreach (InputEntity input in _inputs)
            {
                input.isWasDragging = true;
            }
        }
    }
}
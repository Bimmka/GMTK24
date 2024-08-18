using Entitas;

namespace Code.Gameplay.Input.Systems
{
    public class CleanupWasDraggingMarkSystem : ICleanupSystem
    {
        private readonly IGroup<InputEntity> _inputs;
        public CleanupWasDraggingMarkSystem(InputContext meta)
        {
            _inputs = meta.GetGroup(InputMatcher
                .AllOf(
                    InputMatcher.Input,
                    InputMatcher.WorldMousePosition,
                    InputMatcher.ScreenMousePosition));
        }

        public void Cleanup()
        {
            foreach (InputEntity input in _inputs)
            {
                input.isWasDragging = false;
            }
        }
    }
}
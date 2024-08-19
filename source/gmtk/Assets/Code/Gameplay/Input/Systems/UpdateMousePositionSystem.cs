using Code.Gameplay.Input.Service;
using Entitas;

namespace Code.Gameplay.Input.Systems
{
    public class UpdateMousePositionSystem : IExecuteSystem
    {
        private readonly IInputService _inputService;
        private readonly IGroup<InputEntity> _inputs;
        public UpdateMousePositionSystem(InputContext meta, IInputService inputService)
        {
            _inputService = inputService;
            _inputs = meta.GetGroup(InputMatcher
                .AllOf(
                    InputMatcher.Input,
                    InputMatcher.WorldMousePosition,
                    InputMatcher.ScreenMousePosition));
        }

        public void Execute()
        {
            foreach (InputEntity input in _inputs)
            {
                input.ReplaceWorldMousePosition(_inputService.GetWorldMousePosition());
                input.ReplaceScreenMousePosition(_inputService.GetScreenMousePosition());
            }
        }
    }
}
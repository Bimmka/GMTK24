using Code.Gameplay.Input.Service;
using Entitas;

namespace Code.Gameplay.Input.Systems
{
  public class EmitInputSystem : IExecuteSystem
  {
    private readonly IInputService _inputService;
    private readonly IGroup<InputEntity> _inputs;

    public EmitInputSystem(InputContext input, IInputService inputService)
    {
      _inputService = inputService;
      _inputs = input.GetGroup(InputMatcher.Input);
    }
    
    public void Execute()
    {
      foreach (InputEntity input in _inputs)
      {
        input.isMouseDown = _inputService.GetLeftMouseButtonDown();
        input.isMousePressed = _inputService.GetLeftMouseButton();
        input.isMouseUp = _inputService.GetLeftMouseButtonUp();
        input.isModeSwitch = _inputService.GetModeSwitchButton();
      }
    }
  }
}
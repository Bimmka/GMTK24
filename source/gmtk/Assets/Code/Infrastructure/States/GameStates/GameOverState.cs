using Code.Gameplay.Windows;
using Code.Gameplay.Windows.Service;
using Code.Infrastructure.States.StateInfrastructure;

namespace Code.Infrastructure.States.GameStates
{
  public class GameOverState : SimpleState
  {
    private readonly IWindowService _windowService;

    public GameOverState(IWindowService windowService)
    {
      _windowService = windowService;
    }
    
    public override void Enter()
    {
     
      
     
    }
  }
}
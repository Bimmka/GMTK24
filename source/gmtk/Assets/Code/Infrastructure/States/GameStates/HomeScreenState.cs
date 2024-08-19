using Code.Gameplay.Windows.Base;
using Code.Gameplay.Windows.Service;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Meta;

namespace Code.Infrastructure.States.GameStates
{
  public class HomeScreenState : EndOfFrameExitState
  {
    private readonly IWindowService _windowService;

    private HomeScreenFeature _homeScreenFeature;

    public HomeScreenState(IWindowService windowService)
    {
      _windowService = windowService;
    }

    public override void Enter()
    {
      _windowService.Open(WindowId.HomeScreenBackground);
      _windowService.Open(WindowId.HomeScreenMenu);
    }

    protected override void OnUpdate()
    {
    }

    protected override void ExitOnEndOfFrame()
    {
    }
  }
}
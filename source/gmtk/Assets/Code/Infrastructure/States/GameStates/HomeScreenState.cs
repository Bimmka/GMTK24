using Code.Gameplay.Levels;
using Code.Gameplay.Windows.Base;
using Code.Gameplay.Windows.Service;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Meta;

namespace Code.Infrastructure.States.GameStates
{
  public class HomeScreenState : EndOfFrameExitState
  {
    private readonly IWindowService _windowService;
    private readonly ILevelDataProvider _levelDataProvider;

    private HomeScreenFeature _homeScreenFeature;

    public HomeScreenState(IWindowService windowService, ILevelDataProvider levelDataProvider)
    {
      _windowService = windowService;
      _levelDataProvider = levelDataProvider;
    }

    public override void Enter()
    {
      _windowService.CloseAll();

      _windowService.Open(WindowId.HomeScreenBackground);
      _windowService.Open(WindowId.HomeScreenMenu);

      if (string.IsNullOrEmpty(_levelDataProvider.CurrentId) == false)
        _windowService.Open(WindowId.GameLevels);
    }

    protected override void OnUpdate()
    {
    }

    protected override void ExitOnEndOfFrame()
    {
    }
  }
}
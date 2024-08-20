using Code.Gameplay.Levels;
using Code.Gameplay.Sounds.Config;
using Code.Gameplay.Sounds.Service;
using Code.Gameplay.Windows.Base;
using Code.Gameplay.Windows.Service;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Meta;
using UnityEngine;

namespace Code.Infrastructure.States.GameStates
{
  public class HomeScreenState : EndOfFrameExitState
  {
    private readonly IWindowService _windowService;
    private readonly ILevelDataProvider _levelDataProvider;
    private readonly IAudioService _audioService;
    private readonly IMenuDataProvider _menuDataProvider;

    private HomeScreenFeature _homeScreenFeature;

    public HomeScreenState(IWindowService windowService, ILevelDataProvider levelDataProvider, IAudioService audioService, IMenuDataProvider menuDataProvider)
    {
      _windowService = windowService;
      _levelDataProvider = levelDataProvider;
      _audioService = audioService;
      _menuDataProvider = menuDataProvider;
    }

    public override void Enter()
    {
      _audioService.PlayMainThemeWithTransitDuration(SoundType.MenuMainTheme, 0.3f);
      _windowService.CloseAll();

      if (string.IsNullOrEmpty(_levelDataProvider.CurrentId) == false)
      {
        _windowService.Open(WindowId.GameLevels);
        if (_menuDataProvider.ObjectsToHide != null)
        {
          foreach (GameObject gameObject in _menuDataProvider.ObjectsToHide)
          {
            gameObject.SetActive(false);
          }
        }
      }
      else
      {
        _windowService.Open(WindowId.HomeScreenMenu);
      }
    }

    protected override void OnUpdate()
    {
    }

    protected override void ExitOnEndOfFrame()
    {
    }
  }
}
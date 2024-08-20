using Code.Gameplay.Sounds.Service;
using Code.Infrastructure.Loading;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;

namespace Code.Infrastructure.States.GameStates
{
  public class LoadingHomeScreenState : SimpleState
  {
    private const string HomeScreenSceneName = "HomeScreen";

    private readonly IGameStateMachine _stateMachine;
    private readonly ISceneLoader _sceneLoader;
    private readonly IAudioService _audioService;

    public LoadingHomeScreenState(IGameStateMachine stateMachine, ISceneLoader sceneLoader, IAudioService audioService)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
      _audioService = audioService;
    }
    
    public override void Enter()
    {
      _audioService.UpdateParameters();
      _sceneLoader.LoadScene(HomeScreenSceneName, EnterHomeScreenState);
    }

    private void EnterHomeScreenState()
    {
      _stateMachine.Enter<HomeScreenState>();
    }
  }
}
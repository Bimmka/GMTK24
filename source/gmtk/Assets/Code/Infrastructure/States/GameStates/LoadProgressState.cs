using Code.Gameplay.Sounds.Service;
using Code.Gameplay.StaticData;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using Code.Progress.SaveLoad;

namespace Code.Infrastructure.States.GameStates
{
  public class LoadProgressState : SimpleState
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly IStaticDataService _staticDataService;
    private readonly IAudioService _audioService;
    private readonly ISaveLoadService _saveLoadService;

    public LoadProgressState(
      IGameStateMachine stateMachine,
      ISaveLoadService saveLoadService,
      IStaticDataService staticDataService,
      IAudioService audioService)
    {
      _saveLoadService = saveLoadService;
      _stateMachine = stateMachine;
      _staticDataService = staticDataService;
      _audioService = audioService;
    }
    
    public override void Enter()
    {
      InitializeProgress();
      
      _audioService.RestoreParameters(_saveLoadService.LoadAudioPreferences());

      _stateMachine.Enter<ActualizeProgressState>();
    }

    private void InitializeProgress()
    {
      if (_saveLoadService.HasSavedProgress)
        _saveLoadService.LoadProgress();
      else
        CreateNewProgress();
    }

    private void CreateNewProgress()
    {
      _saveLoadService.CreateProgress();
    }
  }
}
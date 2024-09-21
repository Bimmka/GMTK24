using Code.Gameplay.Common.Time;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.Systems;
using Code.Progress.Data;
using Code.Progress.Provider;
using Code.Progress.SaveLoad;

namespace Code.Infrastructure.States.GameStates
{
  public class ActualizeProgressState : SimpleState
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly ITimeService _time;
    private readonly IProgressProvider _progressProvider;
    private readonly ISystemFactory _systemFactory;
    private readonly ISaveLoadService _saveLoadService;
      
    public ActualizeProgressState(
      IGameStateMachine stateMachine,
      ITimeService time,
      IProgressProvider progressProvider,
      ISaveLoadService saveLoadService,
      ISystemFactory systemFactory)
    {
      _saveLoadService = saveLoadService;
      _stateMachine = stateMachine;
      _time = time;
      _progressProvider = progressProvider;
      _systemFactory = systemFactory;
    }
    
    public override void Enter()
    {
      ActualizeProgress(_progressProvider.ProgressData);
      
      _stateMachine.Enter<LoadingHomeScreenState>();
    }

    private void ActualizeProgress(ProgressData data)
    {
      _saveLoadService.SaveProgress();
    }

    protected override void Exit()
    {
    
    }
  }
}
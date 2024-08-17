using Code.Gameplay;
using Code.Gameplay.Features.Level.Config;
using Code.Gameplay.Features.Stalls.Factory;
using Code.Gameplay.Levels;
using Code.Gameplay.StaticData;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.Systems;

namespace Code.Infrastructure.States.GameStates
{
  public class BattleEnterState : SimpleState
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly ILevelDataProvider _levelDataProvider;
    private readonly IStallsFactory _stallsFactory;
    private readonly IStaticDataService _staticDataService;
    private readonly ISystemFactory _systems;
    private readonly GameContext _gameContext;

    public BattleEnterState(
      IGameStateMachine stateMachine, 
      ILevelDataProvider levelDataProvider,
      IStallsFactory stallsFactory,
      IStaticDataService staticDataService)
    {
      _stateMachine = stateMachine;
      _levelDataProvider = levelDataProvider;
      _stallsFactory = stallsFactory;
      _staticDataService = staticDataService;
    }
    
    public override void Enter()
    {
      PlaceStalls();
      
      _stateMachine.Enter<BattleLoopState>();
    }

    private void PlaceStalls()
    {
      LevelConfig config = _staticDataService.GetLevelConfig(_levelDataProvider.CurrentId);

      foreach (StallsSpawnData spawnData in config.StallsSpawnData)
      {
        _stallsFactory.CreateStall(spawnData, _levelDataProvider.StallSpawnParent);
      }
    }
  }
}
using Code.Gameplay;
using Code.Gameplay.Levels;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.Systems;

namespace Code.Infrastructure.States.GameStates
{
  public class BattleEnterState : SimpleState
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly ILevelDataProvider _levelDataProvider;
    private readonly ISystemFactory _systems;
    private readonly GameContext _gameContext;
    private BattleFeature _battleFeature;

    public BattleEnterState(
      IGameStateMachine stateMachine, 
      ILevelDataProvider levelDataProvider)
    {
      _stateMachine = stateMachine;
      _levelDataProvider = levelDataProvider;
    }
    
    public override void Enter()
    {
      PlaceHero();  
      
      _stateMachine.Enter<BattleLoopState>();
    }

    private void PlaceHero()
    {
    }
  }
}
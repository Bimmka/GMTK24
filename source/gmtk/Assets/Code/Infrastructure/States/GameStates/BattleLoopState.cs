using Code.Gameplay;
using Code.Gameplay.Features.Stalls.Services;
using Code.Gameplay.VFX.Service;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.Systems;

namespace Code.Infrastructure.States.GameStates
{
  public class BattleLoopState : EndOfFrameExitState
  {
    private readonly ISystemFactory _systems;
    private readonly GameContext _gameContext;
    private readonly IVFXService _vfxService;
    private readonly IStallService _stallService;
    private readonly InputContext _inputContext;
    
    private BattleFeature _battleFeature;

    public BattleLoopState(ISystemFactory systems,
      GameContext gameContext,
      IVFXService vfxService,
      IStallService stallService,
      InputContext inputContext)
    {
      _systems = systems;
      _gameContext = gameContext;
      _vfxService = vfxService;
      _stallService = stallService;
      _inputContext = inputContext;
    }
    
    public override void Enter()
    {
      _battleFeature = _systems.Create<BattleFeature>();
      _battleFeature.Initialize();
    }

    protected override void OnUpdate()
    {
      _battleFeature.Execute();
      _battleFeature.Cleanup();
    }

    protected override void ExitOnEndOfFrame()
    {
      _battleFeature.DeactivateReactiveSystems();
      _battleFeature.ClearReactiveSystems();

      DestructEntities();

      _battleFeature.Cleanup();
      _battleFeature.TearDown();
      _battleFeature = null;

      _vfxService.Clear();

      _stallService.Clear();
    
    }

    private void DestructEntities()
    {
      foreach (GameEntity entity in _gameContext.GetEntities()) 
        entity.isDestructed = true;
      
      _inputContext.DestroyAllEntities();
    }
  }
}
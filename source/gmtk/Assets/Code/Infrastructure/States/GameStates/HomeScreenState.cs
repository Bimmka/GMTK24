using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.Systems;
using Code.Meta;

namespace Code.Infrastructure.States.GameStates
{
  public class HomeScreenState : EndOfFrameExitState
  {
    private readonly ISystemFactory _systems;
    private readonly GameContext _gameContext;

    private HomeScreenFeature _homeScreenFeature;

    public HomeScreenState(
      ISystemFactory systems, 
      GameContext gameContext)
    {
      _systems = systems;
      _gameContext = gameContext;
    }

    public override void Enter()
    {
      _homeScreenFeature = _systems.Create<HomeScreenFeature>();
      _homeScreenFeature.Initialize();
    }

    protected override void OnUpdate()
    {
      _homeScreenFeature.Execute();
      _homeScreenFeature.Cleanup();
    }

    protected override void ExitOnEndOfFrame()
    {
      _homeScreenFeature.DeactivateReactiveSystems();
      _homeScreenFeature.ClearReactiveSystems();

      DestructEntities();
      
      _homeScreenFeature.Cleanup();
      _homeScreenFeature.TearDown();
      _homeScreenFeature = null;
    }
    
    private void DestructEntities()
    {
      foreach (GameEntity entity in _gameContext.GetEntities()) 
        entity.isDestructed = true;
    }
  }
}
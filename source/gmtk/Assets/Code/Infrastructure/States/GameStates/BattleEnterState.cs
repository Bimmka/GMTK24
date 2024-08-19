using Code.Common.Extensions;
using Code.Gameplay;
using Code.Gameplay.Features.Foxes.Factory;
using Code.Gameplay.Features.Infections.Factory;
using Code.Gameplay.Features.Level.Config;
using Code.Gameplay.Features.Rabbits.Factory;
using Code.Gameplay.Features.Stalls.Factory;
using Code.Gameplay.Features.Stalls.Services;
using Code.Gameplay.Levels;
using Code.Gameplay.StaticData;
using Code.Gameplay.Windows;
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
    private readonly IStallService _stallService;
    private readonly IRabbitFactory _rabbitFactory;
    private readonly IWindowService _windowService;
    private readonly IInfectionFactory _infectionFactory;
    private readonly IFoxFactory _foxFactory;
    private readonly ISystemFactory _systems;
    private readonly GameContext _gameContext;

    public BattleEnterState(
      IGameStateMachine stateMachine, 
      ILevelDataProvider levelDataProvider,
      IStallsFactory stallsFactory,
      IStaticDataService staticDataService,
      IStallService stallService,
      IRabbitFactory rabbitFactory,
      IWindowService windowService,
      IInfectionFactory infectionFactory,
      IFoxFactory foxFactory)
    {
      _stateMachine = stateMachine;
      _levelDataProvider = levelDataProvider;
      _stallsFactory = stallsFactory;
      _staticDataService = staticDataService;
      _stallService = stallService;
      _rabbitFactory = rabbitFactory;
      _windowService = windowService;
      _infectionFactory = infectionFactory;
      _foxFactory = foxFactory;
    }
    
    public override void Enter()
    {
      LevelConfig config = _staticDataService.GetLevelConfig(_levelDataProvider.CurrentId);
      
      PlaceStalls(config.StallsSpawnData);
      PlaceRabbits(config.PresetupRabbits);
      PlaceLevelInfections(config.Infections);
      PlaceFoxes(config.PresetupFoxesData);
      
      _windowService.Open(WindowId.MultipleSelectionWindow);
      
      _stateMachine.Enter<BattleLoopState>();
    }

    private void PlaceStalls(StallsSpawnData[] stallsSpawnData)
    {
      foreach (StallsSpawnData spawnData in stallsSpawnData)
      {
        GameEntity stall = _stallsFactory.CreateStall(spawnData, _levelDataProvider.StallSpawnParent);
        _stallService.Registry(spawnData.Index, stall);
      }
    }

    private void PlaceRabbits(PresetupRabbitData[] presetupRabbits)
    {
      foreach (PresetupRabbitData rabbit in presetupRabbits)
      {
        _rabbitFactory
          .Create(rabbit.Type, _stallService.GetRandomPositionInStall(rabbit.StallIndex), rabbit.StallIndex)
          .With(x => x.isMovementAvailable = true)
          .With(x => x.isWaitingForMoving = true)
          .With(x => x.isCanBeChosenForReplication = true)
          .With(x => x.isWaitingForNextReplicationUp = true)
          ;
      }
    }

    private void PlaceLevelInfections(InfectionForLevelData[] infections)
    {
      foreach (InfectionForLevelData infection in infections)
      {
        _infectionFactory.CreateLevelInfection(infection.Type, infection.Interval);
      }
    }
    
    private void PlaceFoxes(PresetupFoxesData[] foxes)
    {
      foreach (PresetupFoxesData fox in foxes)
      {
        _foxFactory.Create(_stallService.GetRandomPositionInStall(fox.StallIndex), fox.StallIndex);
      }
    }
  }
}
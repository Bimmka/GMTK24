using Code.Common.EntityIndices;
using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Common.Collisions;
using Code.Gameplay.Common.Physics;
using Code.Gameplay.Common.Random;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Input.Service;
using Code.Gameplay.Levels;
using Code.Gameplay.StaticData;
using Code.Gameplay.Windows;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Identifiers;
using Code.Infrastructure.Loading;
using Code.Infrastructure.States.Factory;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.Systems;
using Code.Infrastructure.View.Factory;
using Code.Progress.Provider;
using Code.Progress.SaveLoad;
using RSG;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
  public class BootstrapInstaller : MonoInstaller, ICoroutineRunner, IInitializable
  {
    public override void InstallBindings()
    {
      BindInputService();
      BindInfrastructureServices();
      BindAssetManagementServices();
      BindCommonServices();
      BindSystemFactory();
      BindUIFactories();
      BindContexts();
      BindGameplayServices();
      BindUIServices();
      BindCameraProvider();
      BindGameplayFactories();
      BindEntityIndices();
      BindStateMachine();
      BindStateFactory();
      BindGameStates();
      BindProgressServices();
    }

    private void BindStateMachine()
    {
      Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();
    }

    private void BindStateFactory()
    {
      Container.BindInterfacesAndSelfTo<StateFactory>().AsSingle();
    }

    private void BindGameStates()
    {
      Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
      Container.BindInterfacesAndSelfTo<LoadProgressState>().AsSingle();
      Container.BindInterfacesAndSelfTo<ActualizeProgressState>().AsSingle();
      Container.BindInterfacesAndSelfTo<LoadingHomeScreenState>().AsSingle();
      Container.BindInterfacesAndSelfTo<HomeScreenState>().AsSingle();
      Container.BindInterfacesAndSelfTo<LoadingBattleState>().AsSingle();
      Container.BindInterfacesAndSelfTo<BattleEnterState>().AsSingle();
      Container.BindInterfacesAndSelfTo<BattleLoopState>().AsSingle();
      Container.BindInterfacesAndSelfTo<GameOverState>().AsSingle();
    }

    private void BindContexts()
    {
      Container.Bind<Contexts>().FromInstance(Contexts.sharedInstance).AsSingle();
      
      Container.Bind<GameContext>().FromInstance(Contexts.sharedInstance.game).AsSingle();
      Container.Bind<InputContext>().FromInstance(Contexts.sharedInstance.input).AsSingle();
      Container.Bind<MetaContext>().FromInstance(Contexts.sharedInstance.meta).AsSingle();
    }

    private void BindCameraProvider()
    {
      Container.BindInterfacesAndSelfTo<CameraProvider>().AsSingle();
    }

    private void BindProgressServices()
    {
      Container.Bind<IProgressProvider>().To<ProgressProvider>().AsSingle();
      Container.Bind<ISaveLoadService>().To<SaveLoadService>().AsSingle();
    }

    private void BindGameplayServices()
    {
      Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
      Container.Bind<ILevelDataProvider>().To<LevelDataProvider>().AsSingle();
    }

    private void BindGameplayFactories()
    {
      Container.Bind<IEntityViewFactory>().To<EntityViewFactory>().AsSingle();
    }

    private void BindEntityIndices()
    {
      Container.BindInterfacesAndSelfTo<GameEntityIndices>().AsSingle();
    }

    private void BindSystemFactory()
    {
      Container.Bind<ISystemFactory>().To<SystemFactory>().AsSingle();
    }

    private void BindInfrastructureServices()
    {
      Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
      Container.Bind<IIdentifierService>().To<IdentifierService>().AsSingle();
    }

    private void BindAssetManagementServices()
    {
      Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
    }

    private void BindCommonServices()
    {
      Container.Bind<IRandomService>().To<UnityRandomService>().AsSingle();
      Container.Bind<ICollisionRegistry>().To<CollisionRegistry>().AsSingle();
      Container.Bind<IPhysicsService>().To<PhysicsService>().AsSingle();
      Container.Bind<ITimeService>().To<UnityTimeService>().AsSingle();
      Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
    }

    private void BindInputService()
    {
      Container.Bind<IInputService>().To<StandaloneInputService>().AsSingle();
    }

    private void BindUIServices()
    {
      Container.Bind<IWindowService>().To<WindowService>().AsSingle();
    }

    private void BindUIFactories()
    {
      Container.Bind<IWindowFactory>().To<WindowFactory>().AsSingle();
    }
    
    public void Initialize()
    {
      Promise.UnhandledException += LogPromiseException;
      Container.Resolve<IGameStateMachine>().Enter<BootstrapState>();
    }

    private void LogPromiseException(object sender, ExceptionEventArgs e)
    {
      Debug.LogError(e.Exception);
    }
  }
}
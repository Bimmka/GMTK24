using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Levels;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
  public class LevelInitializer : MonoBehaviour, IInitializable
  {
    public Camera MainCamera;
    public Transform StartPoint;
    public Transform StallSpawnParent;
    public Transform RabbitSpawnParent;
    public Transform FoxesSpawnParent;
    public Transform HolesSpawnParent;

    private ICameraProvider _cameraProvider;
    private ILevelDataProvider _levelDataProvider;

    [Inject]
    private void Construct(
      ICameraProvider cameraProvider, 
      ILevelDataProvider levelDataProvider
      )
    {
      _levelDataProvider = levelDataProvider;
      _cameraProvider = cameraProvider;
    }
    
    public void Initialize()
    {
      _levelDataProvider.SetStartPoint(StartPoint.position);
      _levelDataProvider.SetStallSpawnParent(StallSpawnParent);
      _levelDataProvider.SetRabbitSpawnParent(RabbitSpawnParent);
      _levelDataProvider.SetFoxSpawnParent(FoxesSpawnParent);
      _levelDataProvider.SetHoleSpawnParent(HolesSpawnParent);

      _cameraProvider.SetMainCamera(MainCamera);
    }
  }
}
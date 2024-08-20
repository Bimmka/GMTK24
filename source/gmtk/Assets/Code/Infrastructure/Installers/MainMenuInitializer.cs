using Code.Gameplay.Levels;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class MainMenuInitializer : MonoBehaviour, IInitializable
    {
        public GameObject[] ObjectsToHide; 
      
        private IMenuDataProvider _menuDataProvider;

        [Inject]
        private void Construct(IMenuDataProvider menuDataProvider)
        {
            _menuDataProvider = menuDataProvider;
        }
    
        public void Initialize()
        {
            _menuDataProvider.SetObjectsToHide(ObjectsToHide);
        }
    }
}
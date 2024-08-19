using Code.Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Windows.Windows.HomeScreen.Factory
{
    public class UIGameLevelViewFactory : IUIGameLevelViewFactory
    {
        private const string PrefabPath = "UI/GameLevelView";
        
        private readonly IInstantiator _instantiator;
        private readonly IAssetProvider _assetProvider;

        public UIGameLevelViewFactory(IInstantiator instantiator, IAssetProvider assetProvider)
        {
            _instantiator = instantiator;
            _assetProvider = assetProvider;
        }

        public GameLevelView Create(RectTransform parent)
        {
            var prefab = _assetProvider.LoadAsset<GameLevelView>(PrefabPath);

            return _instantiator.InstantiatePrefabForComponent<GameLevelView>(prefab, parent);
        }
    }
}
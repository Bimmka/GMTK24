using Code.Gameplay.Sounds.Behaviours;
using Code.Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Sounds.Factory
{
    public class AudioFactory : IAudioFactory
    {
        private const string PrefabPath = "Sound/SoundElement";
        
        private readonly IInstantiator _instantiator;
        private readonly IAssetProvider _assetProvider;

        public AudioFactory(IInstantiator instantiator, IAssetProvider assetProvider)
        {
            _instantiator = instantiator;
            _assetProvider = assetProvider;
        }

        public SoundElement Create(Transform parent) =>
            _instantiator.InstantiatePrefabForComponent<SoundElement>(_assetProvider.LoadAsset<SoundElement>(PrefabPath));
    }
}
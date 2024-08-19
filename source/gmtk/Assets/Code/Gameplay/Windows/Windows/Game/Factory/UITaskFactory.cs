﻿using Code.Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Windows.Windows.Game.Factory
{
    public class UITaskFactory : IUITaskFactory
    {
        private const string ConcreteRabbitAmountViewPath = "UI/ConcreteRabbitAmounView";
        
        private readonly IInstantiator _instantiator;
        private readonly IAssetProvider _assetProvider;


        public UITaskFactory(IInstantiator instantiator, IAssetProvider assetProvider)
        {
            _instantiator = instantiator;
            _assetProvider = assetProvider;
        }
        
        public ConcreteRabbitAmountView CreateConcreteRabbitAmountView(RectTransform parent)
        {
            ConcreteRabbitAmountView prefab = _assetProvider.LoadAsset<ConcreteRabbitAmountView>(ConcreteRabbitAmountViewPath);

            return _instantiator.InstantiatePrefabForComponent<ConcreteRabbitAmountView>(prefab, parent);
        }
    }
}
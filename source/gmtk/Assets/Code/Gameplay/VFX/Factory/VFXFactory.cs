using Code.Gameplay.VFX.Behaviours;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.VFX.Factory
{
    public class VFXFactory : IVFXFactory
    {
        private readonly IInstantiator _instantiator;

        public VFXFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }
        
        public VFXElement Create(VFXElement prefab, Vector3 at, Transform parent) =>
            _instantiator.InstantiatePrefabForComponent<VFXElement>(prefab, at, Quaternion.identity, parent);
    }
}
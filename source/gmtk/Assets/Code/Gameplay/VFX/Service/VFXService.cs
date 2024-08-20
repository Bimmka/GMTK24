using System.Collections.Generic;
using Code.Gameplay.Levels;
using Code.Gameplay.StaticData;
using Code.Gameplay.VFX.Behaviours;
using Code.Gameplay.VFX.Config;
using Code.Gameplay.VFX.Factory;
using UnityEngine;

namespace Code.Gameplay.VFX.Service
{
    public class VFXService : IVFXService
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IVFXFactory _vfxFactory;
        private readonly ILevelDataProvider _levelDataProvider;

        private readonly Dictionary<VFXType, Queue<VFXElement>> _savedParticles = new Dictionary<VFXType, Queue<VFXElement>>();

        public VFXService(IStaticDataService staticDataService, IVFXFactory vfxFactory, ILevelDataProvider levelDataProvider)
        {
            _staticDataService = staticDataService;
            _vfxFactory = vfxFactory;
            _levelDataProvider = levelDataProvider;
        }

        public void Spawn(VFXType type, Vector3 at)
        {
            VFXContainer container = _staticDataService.GetVFXContainer(type);
            Spawn(type, at, container.DefaultDuration);
        }
        
        public void Spawn(VFXType type, Vector3 at, float duration)
        {
            VFXElement element;
            if (_savedParticles.ContainsKey(type) && _savedParticles[type].Count > 0)
            {
                element = _savedParticles[type].Dequeue();
            }
            else
            {
                VFXContainer container = _staticDataService.GetVFXContainer(type);
                element = CreateNew(container.Particle, at, _levelDataProvider.RabbitSpawnParent);
            }

            if (element != null)
            {
                element.transform.position = at;
                element.Initialize(type, duration);
                element.Show();
            }
        }

        public void Return(VFXType type, VFXElement element)
        {
            element.Hide();
            
            if (_savedParticles.ContainsKey(type))
                _savedParticles[type].Enqueue(element);
            else
            {
                Queue<VFXElement> queue = new Queue<VFXElement>();
                queue.Enqueue(element);
                _savedParticles.Add(type, queue);
            }
        }

        public void Clear()
        {
            foreach (KeyValuePair<VFXType,Queue<VFXElement>> savedParticle in _savedParticles)
            {
                foreach (VFXElement element in savedParticle.Value)
                {
                    if (element != null)
                        Object.Destroy(element.gameObject);
                }
            }
            
            _savedParticles.Clear();
        }

        private VFXElement CreateNew(VFXElement prefab, Vector3 at, Transform parent) =>
            _vfxFactory.Create(prefab, at, parent);
    }
}
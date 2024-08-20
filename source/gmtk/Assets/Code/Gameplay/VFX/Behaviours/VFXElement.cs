using Code.Gameplay.Common.Time;
using Code.Gameplay.VFX.Config;
using Code.Gameplay.VFX.Service;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.VFX.Behaviours
{
    public class VFXElement : MonoBehaviour
    {
        public ParticleSystem ParticleSystem;
        
        private ITimeService _time;

        private float _timeLeft;
        private VFXType _type;
        private IVFXService _vfxService;

        [Inject]
        private void Construct(ITimeService timeService, IVFXService vfxService)
        {
            _vfxService = vfxService;
            _time = timeService;
        }
        
        public void Initialize(VFXType type, float duration)
        {
            _type = type;
            _timeLeft = duration;
        }

        public void Update()
        {
            _timeLeft -= _time.DeltaTime;
            
            if (_timeLeft <= 0)
                _vfxService.Return(_type, this);
                
        }

        public void Hide()
        {
            ParticleSystem.Stop();
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            ParticleSystem.Play();
        }
    }
}
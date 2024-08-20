using Code.Gameplay.VFX.Behaviours;
using Code.Gameplay.VFX.Config;
using UnityEngine;

namespace Code.Gameplay.VFX.Service
{
    public interface IVFXService
    {
        void Spawn(VFXType type, Vector3 at);
        void Spawn(VFXType type, Vector3 at, float duration);
        void Return(VFXType type, VFXElement element);
        void Clear();
    }
}
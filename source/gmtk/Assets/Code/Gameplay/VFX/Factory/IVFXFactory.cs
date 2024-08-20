using Code.Gameplay.VFX.Behaviours;
using UnityEngine;

namespace Code.Gameplay.VFX.Factory
{
    public interface IVFXFactory
    {
        VFXElement Create(VFXElement prefab, Vector3 at, Transform parent);
    }
}
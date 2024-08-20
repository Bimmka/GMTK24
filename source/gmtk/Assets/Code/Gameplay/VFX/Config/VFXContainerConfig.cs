using UnityEngine;

namespace Code.Gameplay.VFX.Config
{
    [CreateAssetMenu(menuName = "StaticData/VFX/Create VFX Container", fileName = "VFXContainerConfig")]
    public class VFXContainerConfig : ScriptableObject
    {
        public VFXContainer[] VFXContainers;
    }
}
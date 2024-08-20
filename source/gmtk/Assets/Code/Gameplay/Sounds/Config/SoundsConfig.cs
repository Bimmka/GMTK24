using UnityEngine;

namespace Code.Gameplay.Sounds.Config
{
    [CreateAssetMenu(menuName = "StaticData/Sounds/Create Sounds Container", fileName = "SoundsConfig")]
    public class SoundsConfig : ScriptableObject
    {
        public SoundContainer[] SoundContainers;
    }
}
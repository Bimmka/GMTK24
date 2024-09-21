using UnityEngine;
using UnityEngine.Audio;

namespace Code.Gameplay.Sounds.Config
{
    [CreateAssetMenu(menuName = "StaticData/Sounds/Create Sound Mixer Config", fileName = "SoundMixerConfig")]
    public class SoundMixerConfig : ScriptableObject
    {
        public AudioMixer MainMixer;
        public string MainVolumeMixerParameter = "MasterVolume";
        public string EffectsVolumeMixerParameter = "EffectsVolume";
        public string SoundsVolumeMixerParameter = "SoundsVolume"; 
    }
}
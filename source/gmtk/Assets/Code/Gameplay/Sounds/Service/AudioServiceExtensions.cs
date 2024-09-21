using UnityEngine;

namespace Code.Gameplay.Sounds.Service
{
    public static class AudioServiceExtensions
    {
        public static float MixerVolume(this float volume)
        {
            if (volume == 0)
                return -80;

            return Mathf.Log10(volume) * 20;
        }
    }
}
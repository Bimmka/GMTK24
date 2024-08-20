using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Code.Gameplay.Sounds.Config
{
    [Serializable]
    public class SoundContainer
    {
        public SoundType Type;
        public AudioClip Clip;
        public AudioMixerGroup MixerGroup;
        public float Duration;
        public float DefaultVolume;
        public bool IsLoop;
        public bool IsBackground;
    }
}
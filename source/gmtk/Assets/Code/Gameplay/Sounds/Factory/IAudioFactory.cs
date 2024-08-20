using Code.Gameplay.Sounds.Behaviours;
using UnityEngine;

namespace Code.Gameplay.Sounds.Factory
{
    public interface IAudioFactory
    {
        SoundElement Create(Transform parent);
    }
}
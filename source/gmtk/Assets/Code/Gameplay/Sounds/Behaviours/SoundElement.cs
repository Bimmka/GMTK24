using Code.Gameplay.Common.Time;
using Code.Gameplay.Sounds.Config;
using Code.Gameplay.Sounds.Service;
using UnityEngine;
using UnityEngine.Audio;
using Zenject;

namespace Code.Gameplay.Sounds.Behaviours
{
    public class SoundElement : MonoBehaviour
    {
        public AudioSource Source;
        
        private ITimeService _timeService;
        private float _timeLeft;
        private bool _isInfinite;
        private SoundType _type;
        private bool _isIgnoreTimeScale;
        private IAudioService _audioService;

        [Inject]
        private void Construct(ITimeService timeService, IAudioService audioService)
        {
            _audioService = audioService;
            _timeService = timeService;
        }

        public void Initialize(
            SoundType type,
            AudioClip clip,
            AudioMixerGroup mixerGroup,
            float volume,
            float duration,
            bool isLoop,
            bool isIgnoreTimeScale,
            bool isInfinite)
        {
            gameObject.SetActive(true);
            _type = type;
            Source.outputAudioMixerGroup = mixerGroup;
            Source.volume = volume;
            Source.loop = isLoop;
            Source.clip = clip;

            _timeLeft = duration;

            _isInfinite = isInfinite;
            _isIgnoreTimeScale = isIgnoreTimeScale;

            Source.Play();
        }

        public void Reset()
        {
            Source.Stop();
            Return();
        }


        private void Update()
        {
            if (_isIgnoreTimeScale == false)
            {
                if (_timeService.IsPaused)
                    Source.Pause();
                else if (Source.isPlaying == false)
                    Source.Play();

                if (Source.isPlaying && _isInfinite == false)
                {
                    _timeLeft -= _timeService.DeltaTime;

                    
                }
            }
            else if (_isInfinite == false)
            {
                _timeLeft -= Time.deltaTime;
            }
            
            if (_timeLeft <= 0)
                Return();
        }

        private void Return()
        {
            Source.Stop();
            gameObject.SetActive(false);
            
            _audioService.Return(this);
        }
    }
}
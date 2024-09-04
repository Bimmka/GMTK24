using Code.Gameplay.Sounds.Config;
using Code.Gameplay.Sounds.Service;
using Code.Gameplay.VFX.Config;
using Code.Gameplay.VFX.Service;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Death.Systems
{
    public class DeathByRabiesSystem : IExecuteSystem
    {
        private readonly IAudioService _audioService;
        private readonly IVFXService _vfxService;
        private readonly IGroup<GameEntity> _rabbits;

        public DeathByRabiesSystem(GameContext game, IAudioService audioService, IVFXService vfxService)
        {
            _audioService = audioService;
            _vfxService = vfxService;
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.Dead,
                    GameMatcher.CarrierOfRabiesInfection,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                _audioService.PlayAudio(SoundType.DeadByRabies);
                _vfxService.Spawn(VFXType.SickDeath, rabbit.WorldPosition);
            }
        }
    }
}
using Code.Gameplay.Sounds.Config;
using Code.Gameplay.Sounds.Service;
using Code.Gameplay.VFX.Config;
using Code.Gameplay.VFX.Service;
using Entitas;

namespace Code.Gameplay.Features.Foxes.SubFeatures.Death.Systems
{
    public class FoxDeathByRabiesSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _foxes;
        private readonly IVFXService _vfxService;
        private readonly IAudioService _audioService;

        public FoxDeathByRabiesSystem(GameContext game, IAudioService audioService, IVFXService vfxService)
        {
            _audioService = audioService;
            _vfxService = vfxService;
            _foxes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fox,
                    GameMatcher.Dead,
                    GameMatcher.CarrierOfRabiesInfection,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity fox in _foxes)
            {
                _audioService.PlayAudio(SoundType.DeadByRabies);
                _vfxService.Spawn(VFXType.SickDeath, fox.WorldPosition);
            }
        }
    }
}
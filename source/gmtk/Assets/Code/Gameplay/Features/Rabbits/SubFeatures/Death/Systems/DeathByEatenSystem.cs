using Code.Gameplay.Sounds.Config;
using Code.Gameplay.Sounds.Service;
using Code.Gameplay.VFX.Config;
using Code.Gameplay.VFX.Service;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Death.Systems
{
    public class DeathByEatenSystem : IExecuteSystem
    {
        private readonly IAudioService _audioService;
        private readonly IVFXService _vfxService;
        private readonly IGroup<GameEntity> _rabbits;

        public DeathByEatenSystem(GameContext game, IAudioService audioService, IVFXService vfxService)
        {
            _audioService = audioService;
            _vfxService = vfxService;
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.Dead,
                    GameMatcher.Eaten));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                _audioService.PlayAudio(SoundType.DeadByEat);
                _vfxService.Spawn(VFXType.EatenDeath, rabbit.WorldPosition);
            }
        }
    }
}
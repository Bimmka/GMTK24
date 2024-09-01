using System.Collections.Generic;
using Code.Gameplay.Sounds.Config;
using Code.Gameplay.Sounds.Service;
using Code.Gameplay.VFX.Config;
using Code.Gameplay.VFX.Service;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Replication.Systems
{
    public class StartReplicationSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IVFXService _vfxService;
        private readonly IAudioService _audioService;
        private readonly IGroup<GameEntity> _rabbits;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public StartReplicationSystem(GameContext game, IVFXService vfxService, IAudioService audioService)
        {
            _game = game;
            _vfxService = vfxService;
            _audioService = audioService;

            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.ReplicationTarget,
                    GameMatcher.NearReplicationTarget,
                    GameMatcher.DefaultReplicationDuration,
                    GameMatcher.CurrentReplicationDuration,
                    GameMatcher.ReplicationAvailable,
                    GameMatcher.ValidReplicationTarget,
                    GameMatcher.WantToReplicate,
                    GameMatcher.MovingToReplicationTarget,
                    GameMatcher.Alive));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits.GetEntities(_buffer))
            {
                GameEntity target = _game.GetEntityWithId(rabbit.ReplicationTarget);
                
                if (target.isStupidMoveState == false && target.isIdleState == false)
                    continue;

                rabbit.ChangeComponentsForStartReplication();
                target.ChangeComponentsForStartReplication();

                float replicationDuration = rabbit.DefaultReplicationDuration;

                if (target.hasDefaultReplicationDuration)
                {
                    if (target.DefaultReplicationDuration > replicationDuration)
                        replicationDuration = target.DefaultReplicationDuration;

                    target.ReplaceCurrentReplicationDuration(replicationDuration);
                    target.ReplaceReplicationTimeLeft(replicationDuration);
                }

                rabbit.ReplaceCurrentReplicationDuration(replicationDuration);
                rabbit.ReplaceReplicationTimeLeft(replicationDuration);
                
                _vfxService.Spawn(VFXType.Replicate, rabbit.WorldPosition, rabbit.CurrentReplicationDuration);
                _audioService.PlayAudio(SoundType.Replication);
            }
        }
    }
}
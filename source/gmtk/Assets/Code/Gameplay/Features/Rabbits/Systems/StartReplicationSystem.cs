﻿using Entitas;

namespace Code.Gameplay.Features.Rabbits.Systems
{
    public class StartReplicationSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _rabbits;

        public StartReplicationSystem(GameContext game)
        {
            _game = game;
            
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.ReplicationTarget,
                    GameMatcher.NearReplicationTarget,
                    GameMatcher.DefaultReplicationDuration,
                    GameMatcher.ActivityFree,
                    GameMatcher.ReplicationPhase));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                GameEntity target = _game.GetEntityWithId(rabbit.ReplicationTarget);
                
                if (target.isActivityFree == false)
                    continue;

                rabbit.isReplicating = true;
                rabbit.isMovementAvailable = false;
                rabbit.isWaitingForMoving = false;
                
                target.isReplicating = true;
                target.isMovementAvailable = false;
                target.isWaitingForMoving = false;
                target.isReplicationPhase = true;
                target.isMovingPhase = false;

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
            }
        }
    }
}
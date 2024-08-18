﻿using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Replication.Systems
{
    public class MarkWantToReplicateSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;

        public MarkWantToReplicateSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.ReplicationTimeUp,
                    GameMatcher.ReplicationTarget)
                .AnyOf(
                    GameMatcher.IdleState,
                    GameMatcher.StupidMoveState));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                rabbit.isWantToReplicate = true;
            }
        }
    }
}
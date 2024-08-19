using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Replication.Systems
{
    public class ApplyReplicationBlockSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public ApplyReplicationBlockSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.ReplicationBlocked,
                    GameMatcher.ReplicationAvailable)
                .NoneOf(GameMatcher.Replicating));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits.GetEntities(_buffer))
            {
                rabbit.isReplicationAvailable = false;
            }
        }
    }
}
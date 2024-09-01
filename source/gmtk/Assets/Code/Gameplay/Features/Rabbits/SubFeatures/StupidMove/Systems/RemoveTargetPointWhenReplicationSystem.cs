using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.StupidMove.Systems
{
    public class RemoveTargetPointWhenReplicationSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public RemoveTargetPointWhenReplicationSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.Alive,
                    GameMatcher.WantToReplicate,
                    GameMatcher.TargetPoint));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits.GetEntities(_buffer))
            {
                rabbit.RemoveTargetPoint();
            }
        }
    }
}
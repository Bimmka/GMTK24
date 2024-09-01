using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Death.Systems
{
    public class MarkDeadWhenEatenSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _eaten;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public MarkDeadWhenEatenSystem(GameContext game)
        {
            _eaten = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Eaten,
                    GameMatcher.Alive)
                .NoneOf(GameMatcher.Replicating));
        }

        public void Execute()
        {
            foreach (GameEntity eaten in _eaten.GetEntities(_buffer))
            {
                eaten.isDead = true;
                eaten.isAlive = false;
            }
        }
    }
}
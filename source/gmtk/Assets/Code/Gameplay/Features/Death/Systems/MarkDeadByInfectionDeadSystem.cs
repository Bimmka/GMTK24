using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Death.Systems
{
    public class MarkDeadByInfectionDeadSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _infected;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public MarkDeadByInfectionDeadSystem(GameContext game)
        {
            _infected = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.DeadByInfection,
                    GameMatcher.Alive)
                .NoneOf(GameMatcher.Replicating));
        }

        public void Execute()
        {
            foreach (GameEntity infected in _infected.GetEntities(_buffer))
            {
                infected.isDead = true;
                infected.isAlive = false;
            }
        }
    }
}
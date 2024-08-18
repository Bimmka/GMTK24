using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.Infections.Systems
{
    public class RemoveMarkInfectionUpSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _infections;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(8);

        public RemoveMarkInfectionUpSystem(GameContext game)
        {
            _infections = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Infection,
                    GameMatcher.InfectionUp));
        }

        public void Execute()
        {
            foreach (GameEntity infection in _infections.GetEntities(_buffer))
            {
                infection.isInfectionUp = false;
            }
        }
    }
}
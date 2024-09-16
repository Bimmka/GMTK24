using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Infections.Systems
{
    public class ValidateInfectionByCarrierSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _infections;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public ValidateInfectionByCarrierSystem(GameContext game)
        {
            _game = game;
            _infections = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Infection,
                    GameMatcher.CarrierOfInfectionId,
                    GameMatcher.ValidInfection));
        }

        public void Execute()
        {
            foreach (GameEntity infection in _infections.GetEntities(_buffer))
            {
                GameEntity carrier = _game.GetEntityWithId(infection.CarrierOfInfectionId);

                if (carrier == null)
                {
                    infection.isDestructed = true;
                    infection.isValidInfection = false;
                }
            }
        }
    }
}
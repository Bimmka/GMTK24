using Entitas;

namespace Code.Gameplay.Features.Death.Systems
{
    public class MarkDestructedInfectionForDeadSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _deads;
        private readonly IGroup<GameEntity> _infections;

        public MarkDestructedInfectionForDeadSystem(GameContext game)
        {
            _deads = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Dead,
                    GameMatcher.Id));

            _infections = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Infection,
                    GameMatcher.CarrierOfInfectionId));
        }

        public void Execute()
        {
            foreach (GameEntity infection in _infections)
            {
                foreach (GameEntity dead in _deads)
                {
                    if (infection.CarrierOfInfectionId == dead.Id)
                    {
                        infection.isDestructed = true;
                        infection.isValidInfection = false;
                    }
                }
            }
        }
    }
}
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Dead.Systems
{
    public class DestructInfectionForDeadSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;
        private readonly IGroup<GameEntity> _infections;

        public DestructInfectionForDeadSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
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
                foreach (GameEntity rabbit in _rabbits)
                {
                    if (infection.CarrierOfInfectionId == rabbit.Id)
                    {
                        infection.isDestructed = true;
                        infection.isValidInfection = false;
                    }
                }
            }
        }
    }
}
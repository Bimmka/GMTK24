using Entitas;

namespace Code.Gameplay.Features.Infections.Systems
{
    public class RestartInfectionTimeLeftSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _infections;

        public RestartInfectionTimeLeftSystem(GameContext game)
        {
            _infections = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Infection,
                    GameMatcher.TimeLeftBeforeInfection,
                    GameMatcher.InfectionInterval,
                    GameMatcher.InfectionUp,
                    GameMatcher.ValidInfection));
        }

        public void Execute()
        {
            foreach (GameEntity infection in _infections)
            {
                infection.ReplaceTimeLeftBeforeInfection(infection.InfectionInterval);
            }
        }
    }
}
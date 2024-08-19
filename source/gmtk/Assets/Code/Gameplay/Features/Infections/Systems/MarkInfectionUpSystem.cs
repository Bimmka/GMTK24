using Entitas;

namespace Code.Gameplay.Features.Infections.Systems
{
    public class MarkInfectionUpSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _infections;

        public MarkInfectionUpSystem(GameContext game)
        {
            _infections = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Infection,
                    GameMatcher.TimeLeftBeforeInfection));
        }

        public void Execute()
        {
            foreach (GameEntity infection in _infections)
            {
                if (infection.TimeLeftBeforeInfection <= 0)
                    infection.isInfectionUp = true;
            }
        }
    }
}
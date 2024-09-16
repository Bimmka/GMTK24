using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.Infections.Systems
{
    public class UpdateTimeLeftBeforeInfectionSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _infections;

        public UpdateTimeLeftBeforeInfectionSystem(GameContext game, ITimeService time)
        {
            _time = time;
            _infections = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Infection,
                    GameMatcher.TimeLeftBeforeInfection,
                    GameMatcher.ValidInfection));
        }

        public void Execute()
        {
            foreach (GameEntity infection in _infections)
            {
                infection.ReplaceTimeLeftBeforeInfection(infection.TimeLeftBeforeInfection - _time.DeltaTime);
            }
        }
    }
}
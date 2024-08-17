using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.Systems
{
    public class UpdateTimeForReplicationSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _rabbits;

        public UpdateTimeForReplicationSystem(GameContext game, ITimeService time)
        {
            _time = time;

            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.TimeLeftForNextReplication,
                    GameMatcher.WaitingForNextReplicationUp));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                rabbit.ReplaceTimeLeftForNextReplication(rabbit.TimeLeftForNextReplication - _time.DeltaTime);

                if (rabbit.TimeLeftForNextReplication <= 0)
                    rabbit.isReplicationUp = true;
            }
        }
    }
}
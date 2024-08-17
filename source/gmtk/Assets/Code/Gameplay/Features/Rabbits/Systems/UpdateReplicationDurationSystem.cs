using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.Systems
{
    public class UpdateReplicationDurationSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _rabbits;

        public UpdateReplicationDurationSystem(GameContext game, ITimeService time)
        {
            _time = time;
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.Replicating,
                    GameMatcher.CurrentReplicationDuration,
                    GameMatcher.ReplicationTimeLeft,
                    GameMatcher.ReplicationPhase));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                rabbit.ReplaceReplicationTimeLeft(rabbit.ReplicationTimeLeft - _time.DeltaTime);

                if (rabbit.ReplicationTimeLeft <= 0)
                    rabbit.isReplicationFinished = true;
            }
        }
    }
}
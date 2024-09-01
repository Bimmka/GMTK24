using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Replication.Systems
{
    public class UpdateWaitReplicationTimeSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _rabbits;

        public UpdateWaitReplicationTimeSystem(GameContext game, ITimeService time)
        {
            _time = time;
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.WaitReplicationTimeLeft,
                    GameMatcher.ReplicationAvailable,
                    GameMatcher.WantToReplicate,
                    GameMatcher.ValidReplicationTarget)
                .NoneOf(GameMatcher.Replicating));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                rabbit.ReplaceWaitReplicationTimeLeft(rabbit.WaitReplicationTimeLeft - _time.DeltaTime);
            }
        }
    }
}
using Entitas;

namespace Code.Gameplay.Features.Rabbits.Systems
{
    public class ChangeMovingMarkWhenHasReplicationTargetSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;

        public ChangeMovingMarkWhenHasReplicationTargetSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.ReplicationTarget,
                    GameMatcher.ReplicationPhase));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                rabbit.isMoving = rabbit.isNearReplicationTarget == false && rabbit.isMovementAvailable;
            }
        }
    }
}
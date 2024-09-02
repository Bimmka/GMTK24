using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Replication.Systems
{
    public class ResetAliveRabbitWhenInvalidReplicationTargetSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;

        public ResetAliveRabbitWhenInvalidReplicationTargetSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Alive,
                    GameMatcher.Rabbit,
                    GameMatcher.InvalidReplicationTarget,
                    GameMatcher.ReplicationTarget,
                    GameMatcher.RabbitAnimator));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                rabbit.isCanBeChosenForReplication = true;
                rabbit.isWaitingForNextReplicationUp = true;
                rabbit.isCanStartReplication = true;
                
                rabbit.isMovementAvailable = true;
                rabbit.isWaitingForMoving = true;
                
                rabbit.isWaitingForNextReplicationUp = true;

                rabbit.isSelectable = true;
                
                rabbit.RabbitAnimator.PlayIdle();
            }
        }
    }
}
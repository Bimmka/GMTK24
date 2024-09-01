using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Replication.Systems
{
    public class ResetAliveRabbitWhenReplicationFinishedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;

        public ResetAliveRabbitWhenReplicationFinishedSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Alive,
                    GameMatcher.Rabbit,
                    GameMatcher.ReplicationFinished,
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
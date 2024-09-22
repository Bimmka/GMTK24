using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.States.Systems
{
    public class ResetAliveNonDraggingRabbitWhenInvalidReplicationTargetSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;

        public ResetAliveNonDraggingRabbitWhenInvalidReplicationTargetSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Alive,
                    GameMatcher.Rabbit,
                    GameMatcher.InvalidReplicationTarget,
                    GameMatcher.ReplicationTarget,
                    GameMatcher.RabbitAnimator,
                    GameMatcher.RabbitVisualChanger)
                .NoneOf(GameMatcher.Dragging));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                rabbit.isCanBeChosenForReplication = true;
                rabbit.isWaitingForNextReplicationUp = true;
                rabbit.isCanStartReplication = true;
                rabbit.isWaitingForMoving = true;
                rabbit.isMovingToReplicationTarget = false;
                rabbit.isWantToReplicate = false;
                
                rabbit.RabbitAnimator.PlayIdle();
                rabbit.RabbitVisualChanger.RemoveLove();
            }
        }
    }
}
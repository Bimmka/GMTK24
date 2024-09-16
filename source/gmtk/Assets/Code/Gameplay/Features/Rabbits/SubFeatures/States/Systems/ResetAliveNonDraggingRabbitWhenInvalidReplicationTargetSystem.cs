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
                    GameMatcher.RabbitAnimator)
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
                
                rabbit.RabbitAnimator.PlayIdle();
            }
        }
    }
}
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.States.Systems
{
    public class PrepareForReplicationAliveRabbitAfterDraggingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;

        public PrepareForReplicationAliveRabbitAfterDraggingSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.DragFinished,
                    GameMatcher.Alive));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                rabbit.isCanBeChosenForReplication = true;
                rabbit.isWaitingForNextReplicationUp = true;
                rabbit.isCanStartReplication = true;
            }
        }
    }
}
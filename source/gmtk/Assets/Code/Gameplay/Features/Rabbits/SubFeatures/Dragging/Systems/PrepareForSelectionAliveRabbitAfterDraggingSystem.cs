using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Dragging.Systems
{
    public class PrepareForSelectionAliveRabbitAfterDraggingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;

        public PrepareForSelectionAliveRabbitAfterDraggingSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.DragFinished,
                    GameMatcher.Alive,
                    GameMatcher.RabbitAnimator));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                rabbit.isSelectable = true;
            }
        }
    }
}
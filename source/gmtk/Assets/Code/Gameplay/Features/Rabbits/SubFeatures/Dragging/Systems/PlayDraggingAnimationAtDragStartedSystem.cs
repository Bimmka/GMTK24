using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Dragging.Systems
{
    public class PlayDraggingAnimationAtDragStartedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;

        public PlayDraggingAnimationAtDragStartedSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.DragStarted,
                    GameMatcher.RabbitAnimator,
                    GameMatcher.Alive));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                rabbit.RabbitAnimator.PlayDragging();
            }
        }
    }
}
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Dragging.Systems
{
    public class RemoveOnGroundAfterDragStartedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;

        public RemoveOnGroundAfterDragStartedSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.Alive,
                    GameMatcher.DragStarted));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                rabbit.isOnGround = false;
            }
        }
    }
}
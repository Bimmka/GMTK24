using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Dragging.Systems
{
    public class SetOnGroundAfterDragFinishedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;

        public SetOnGroundAfterDragFinishedSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.Alive,
                    GameMatcher.DragFinished));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                rabbit.isOnGround = true;
            }
        }
    }
}
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Dragging.Systems
{
    public class RefreshDragReleaseTimeSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;

        public RefreshDragReleaseTimeSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.DragFinished,
                    GameMatcher.SelectionDragMaxTime,
                    GameMatcher.SelectionDragTimeLeft));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                rabbit.ReplaceSelectionDragTimeLeft(rabbit.SelectionDragMaxTime);
            }
        }
    }
}
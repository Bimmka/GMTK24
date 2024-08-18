using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.Selection.SubFeatures.ReleaseByTime
{
    public class UpdateReleaseTimeLeftSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _selected;

        public UpdateReleaseTimeLeftSystem(GameContext game, ITimeService time)
        {
            _time = time;

            _selected = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Selected,
                    GameMatcher.SelectionDragTimeLeft,
                    GameMatcher.Dragging,
                    GameMatcher.DraggingState));
        }

        public void Execute()
        {
            foreach (GameEntity selected in _selected)
            {
                selected.ReplaceSelectionDragTimeLeft(selected.SelectionDragTimeLeft - _time.DeltaTime);
            }
        }
    }
}
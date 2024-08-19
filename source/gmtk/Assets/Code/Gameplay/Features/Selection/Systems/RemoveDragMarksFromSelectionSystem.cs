using Entitas;

namespace Code.Gameplay.Features.Selection.Systems
{
    public class RemoveDragMarksFromSelectionSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _selections;

        public RemoveDragMarksFromSelectionSystem(GameContext game)
        {
            _selections = game.GetGroup(GameMatcher.AllOf(GameMatcher.Selection));
        }

        public void Cleanup()
        {
            foreach (GameEntity selection in _selections)
            {
                selection.isDragStarted = false;
                selection.isDragStopped = false;
            }
        }
    }
}
using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Dragging.Systems
{
    public class CleanupDragComponentsWhenDragFinishedSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _rabbits;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public CleanupDragComponentsWhenDragFinishedSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.DragFinished,
                    GameMatcher.AfterDragPosition,
                    GameMatcher.ShiftFromSelect,
                    GameMatcher.SavedPositionBeforeDrag));
        }

        public void Cleanup()
        {
            foreach (GameEntity rabbit in _rabbits.GetEntities(_buffer))
            {
                rabbit.RemoveAfterDragPosition();
                rabbit.RemoveShiftFromSelect();
                rabbit.RemoveSavedPositionBeforeDrag();
            }
        }
    }
}
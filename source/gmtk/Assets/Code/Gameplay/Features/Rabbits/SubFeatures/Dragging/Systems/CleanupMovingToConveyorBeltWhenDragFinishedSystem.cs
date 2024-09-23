using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Dragging.Systems
{
    public class CleanupMovingToConveyorBeltWhenDragFinishedSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _rabbits;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(4);

        public CleanupMovingToConveyorBeltWhenDragFinishedSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.DragFinished,
                    GameMatcher.MovingToConveyorBeltAfterDrag));
        }

        public void Cleanup()
        {
            foreach (GameEntity rabbit in _rabbits.GetEntities(_buffer))
            {
                rabbit.isMovingToConveyorBeltAfterDrag = false;
            }
        }
    }
}
using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Dragging.Systems
{
    public class StopPlayingDraggingSoundAtDragFinishedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(8);

        public StopPlayingDraggingSoundAtDragFinishedSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.DragFinished,
                    GameMatcher.AttachedSound));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits.GetEntities(_buffer))
            {
                rabbit.AttachedSound?.Reset();
                rabbit.RemoveAttachedSound();
            }
        }
    }
}
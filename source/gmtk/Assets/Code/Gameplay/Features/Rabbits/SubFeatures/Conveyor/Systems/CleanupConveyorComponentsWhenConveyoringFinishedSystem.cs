using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Conveyor.Systems
{
    public class CleanupConveyorComponentsWhenConveyoringFinishedSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _rabbits;
        private readonly List<GameEntity> _buffer = new(16);

        public CleanupConveyorComponentsWhenConveyoringFinishedSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.ConveyoringFinished,
                    GameMatcher.ParentConveyorBeltId));
        }

        public void Cleanup()
        {
            foreach (GameEntity rabbit in _rabbits.GetEntities(_buffer))
            {
                rabbit.isConveyoringFinished = false;

                rabbit.RemoveParentConveyorBeltId();
            }
        }
    }
}
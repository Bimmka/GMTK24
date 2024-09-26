using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.ConveyorBelt.Systems
{
    public class PutElementsOnAfterDragFinishedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _conveyorBelts;
        private readonly IGroup<GameEntity> _newElements;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(4);

        public PutElementsOnAfterDragFinishedSystem(GameContext game)
        {
            _conveyorBelts = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ElementsOnConveyor,
                    GameMatcher.Id));

            _newElements = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.ParentConveyorBeltId,
                    GameMatcher.DragFinished,
                    GameMatcher.MovingToConveyorBeltAfterDrag,
                    GameMatcher.WorldPosition,
                    GameMatcher.Alive)
                .NoneOf(GameMatcher.OnConveyorBelt));
        }

        public void Execute()
        {
            foreach (GameEntity conveyorBelt in _conveyorBelts)
            {
                foreach (GameEntity newElement in _newElements.GetEntities(_buffer))
                {
                    if (newElement.ParentConveyorBeltId != conveyorBelt.Id)
                        continue;
                    
                    conveyorBelt.ElementsOnConveyor.Add(newElement.Id);
                    newElement.isOnConveyorBelt = true;
                    newElement.isConveyoringStarted = true;
                }
            }
        }
    }
}
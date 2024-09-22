using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.ConveyorBelt.Systems
{
    public class RemoveInvalidElementsSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _conveyorBelts;
        private readonly List<int> _invalidElements = new List<int>(16);

        public RemoveInvalidElementsSystem(GameContext game)
        {
            _game = game;
            _conveyorBelts = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.ElementsOnConveyor));
        }

        public void Execute()
        {
            foreach (GameEntity conveyorBelt in _conveyorBelts)
            {
                foreach (int elementId in conveyorBelt.ElementsOnConveyor)
                {
                    GameEntity element = _game.GetEntityWithId(elementId);
                    if (element == null || IsElementValid(element) == false)
                        _invalidElements.Add(elementId);
                }

                foreach (int invalidElement in _invalidElements)
                {
                    conveyorBelt.ElementsOnConveyor.Remove(invalidElement);
                }
                
                _invalidElements.Clear();
            }
        }

        private bool IsElementValid(GameEntity element)
        {
            return element.isAlive && element.isOnConveyorBelt && element.hasWorldPosition && element.hasStallParentIndex;
        }
    }
}
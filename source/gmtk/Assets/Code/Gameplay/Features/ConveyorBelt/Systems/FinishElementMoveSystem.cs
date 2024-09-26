using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.ConveyorBelt.Systems
{
    public class FinishElementMoveSystem : IExecuteSystem
    {
        private const float FinishGap = 0.5f;
        
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _conveyorBelts;
        private readonly List<int> _finishedElements = new List<int>(16);

        public FinishElementMoveSystem(GameContext game)
        {
            _game = game;
            _conveyorBelts = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ElementsOnConveyor,
                    GameMatcher.ConveyorEndPoint,
                    GameMatcher.ConveyorEndStall));
        }

        public void Execute()
        {
            foreach (GameEntity conveyorBelt in _conveyorBelts)
            {
                foreach (int elementId in conveyorBelt.ElementsOnConveyor)
                {
                    GameEntity element = _game.GetEntityWithId(elementId);

                    if (Vector3.SqrMagnitude(element.WorldPosition - conveyorBelt.ConveyorEndPoint) <= FinishGap)
                    {
                        element.isOnConveyorBelt = false;
                        element.isConveyoringFinished = true;
                        element.ReplaceStallParentIndex(conveyorBelt.ConveyorEndStall);
                        _finishedElements.Add(elementId);
                    }
                }

                foreach (int finishedElement in _finishedElements)
                {
                    conveyorBelt.ElementsOnConveyor.Remove(finishedElement);
                }
                
                _finishedElements.Clear();
            }
        }
    }
}
using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.ConveyorBelt.Systems
{
    public class MoveElementsSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _conveyorBelts;

        public MoveElementsSystem(GameContext game, ITimeService time)
        {
            _game = game;
            _time = time;
            _conveyorBelts = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ConveyorEndPoint,
                    GameMatcher.Speed,
                    GameMatcher.ElementsOnConveyor));
        }

        public void Execute()
        {
            foreach (GameEntity conveyorBelt in _conveyorBelts)
            {
                foreach (int elementId in conveyorBelt.ElementsOnConveyor)
                {
                    GameEntity element = _game.GetEntityWithId(elementId);
                    
                    if (element == null || element.hasWorldPosition == false)
                        continue;

                    Vector3 moveDirection = (conveyorBelt.ConveyorEndPoint - element.WorldPosition).normalized;

                    element.ReplaceWorldPosition(element.WorldPosition + moveDirection * _time.DeltaTime * conveyorBelt.Speed);
                }
            }
        }
    }
}
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Foxes.Systems
{
    public class RemoveMarkMovingUpSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _foxes;

        public RemoveMarkMovingUpSystem(GameContext game)
        {
            _foxes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fox,
                    GameMatcher.Alive));
        }

        public void Execute()
        {
            foreach (GameEntity fox in _foxes)
            {
                fox.isMovingUp = false;
            }
        }
    }
}
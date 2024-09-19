using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Foxes.SubFeatures.Hunt.Systems
{
    public class MarkNearHuntTargetSystem : IExecuteSystem
    {
        private const float DistanceError = 0.5f; 
        
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _foxes;

        public MarkNearHuntTargetSystem(GameContext game)
        {
            _game = game;
            _foxes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fox,
                    GameMatcher.Hungry,
                    GameMatcher.Alive,
                    GameMatcher.HuntTarget,
                    GameMatcher.ValidHuntTarget,
                    GameMatcher.MovingToHuntTarget,
                    GameMatcher.MovementAvailable,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity fox in _foxes)
            {
                GameEntity huntTarget = _game.GetEntityWithId(fox.HuntTarget);

                if (Vector3.Distance(huntTarget.WorldPosition, fox.WorldPosition) <= DistanceError)
                    fox.isNearHuntTarget = true;
            }
        }
    }
}
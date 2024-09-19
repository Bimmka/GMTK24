using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Foxes.SubFeatures.Hunt.Systems
{
    public class StopMovingToRandomPointAtHuntStartSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _foxes;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public StopMovingToRandomPointAtHuntStartSystem(GameContext game)
        {
            _foxes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fox,
                    GameMatcher.Hungry,
                    GameMatcher.Alive,
                    GameMatcher.MovingToRandomPoint,
                    GameMatcher.TargetPoint,
                    GameMatcher.MovingToHuntTarget));
        }

        public void Execute()
        {
            foreach (GameEntity fox in _foxes.GetEntities(_buffer))
            {
                fox.isMovingToRandomPoint = false;
                fox.RemoveTargetPoint();
            }
        }
    }
}
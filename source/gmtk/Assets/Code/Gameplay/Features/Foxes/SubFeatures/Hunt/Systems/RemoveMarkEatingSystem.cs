using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Foxes.SubFeatures.Hunt.Systems
{
    public class RemoveMarkEatingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _foxes;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public RemoveMarkEatingSystem(GameContext game)
        {
            _foxes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fox,
                    GameMatcher.Eating,
                    GameMatcher.Alive,
                    GameMatcher.EatingFinished));
        }

        public void Execute()
        {
            foreach (GameEntity fox in _foxes.GetEntities(_buffer))
            {
                fox.isEating = false;
            }
        }
    }
}
using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Foxes.SubFeatures.Hunt.Systems
{
    public class StopEatingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _foxes;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public StopEatingSystem(GameContext game)
        {
            _foxes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fox,
                    GameMatcher.Alive,
                    GameMatcher.Eating,
                    GameMatcher.EatingFinished,
                    GameMatcher.FoxAnimator,
                    GameMatcher.TargetAmountGot));
        }

        public void Execute()
        {
            foreach (GameEntity fox in _foxes.GetEntities(_buffer))
            {
                fox.FoxAnimator.PlayIdle();

                fox.isMovementAvailable = true;
                fox.isWaitingNextHuntTarget = true;

                fox.ReplaceTargetAmountGot(fox.TargetAmountGot + 1);
            }
        }
    }
}
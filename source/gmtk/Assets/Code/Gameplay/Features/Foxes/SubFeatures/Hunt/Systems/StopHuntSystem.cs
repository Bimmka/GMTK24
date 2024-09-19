using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Foxes.SubFeatures.Hunt.Systems
{
    public class StopHuntSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _foxes;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public StopHuntSystem(GameContext game)
        {
            _foxes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fox,
                    GameMatcher.Alive,
                    GameMatcher.HuntFinished,
                    GameMatcher.BeforeNextHuntInterval,
                    GameMatcher.BeforeNextHuntTimeLeft,
                    GameMatcher.HuntDuration,
                    GameMatcher.HuntTimeLeft,
                    GameMatcher.TargetAmountGot)
                .NoneOf(GameMatcher.Hungry));
        }

        public void Execute()
        {
            foreach (GameEntity fox in _foxes.GetEntities(_buffer))
            {
                fox.isWaitingHunt = true;
                fox.isWaitingNextHuntTarget = true;

                fox.ReplaceBeforeNextHuntTimeLeft(fox.BeforeNextHuntInterval);
                fox.ReplaceHuntTimeLeft(fox.HuntDuration);
                fox.ReplaceTargetAmountGot(0);

                fox.isMovingToHuntTarget = false;
            }
        }
    }
}
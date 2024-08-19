using Code.Gameplay.Features.Stalls.Services;
using Entitas;

namespace Code.Gameplay.Features.Foxes.Systems
{
    public class StartMovingToRandomPointSystem : IExecuteSystem
    {
        private readonly IStallService _stallService;
        private readonly IGroup<GameEntity> _foxes;

        public StartMovingToRandomPointSystem(GameContext game, IStallService stallService)
        {
            _stallService = stallService;
            
            _foxes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fox,
                    GameMatcher.MovingUp,
                    GameMatcher.Alive,
                    GameMatcher.StallParentIndex,
                    GameMatcher.FoxAnimator,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity fox in _foxes)
            {
                fox.ReplaceTargetPoint(_stallService.GetRandomPositionInStall(fox.StallParentIndex));
                fox.isMovingToRandomPoint = true;
                fox.isMoving = true;
                fox.isWaitingForMoving = false;

                fox.FoxAnimator.PlayMove();
                fox.ReplaceMoveDirection((fox.TargetPoint - fox.WorldPosition).normalized);
            }
        }
    }
}
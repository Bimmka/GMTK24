using Code.Gameplay.Features.Stalls.Services;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Dragging.Systems
{
    public class ValidateStallParentIndexAfterDragFinishedSystem : IExecuteSystem
    {
        private readonly IStallService _stallService;
        private readonly IGroup<GameEntity> _rabbits;

        public ValidateStallParentIndexAfterDragFinishedSystem(GameContext game, IStallService stallService)
        {
            _stallService = stallService;
            
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.Alive,
                    GameMatcher.DragFinished,
                    GameMatcher.WorldPosition,
                    GameMatcher.StallParentIndex));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                rabbit.ReplaceStallParentIndex(_stallService.GetStallIndex(rabbit.WorldPosition));
            }
        }
    }
}
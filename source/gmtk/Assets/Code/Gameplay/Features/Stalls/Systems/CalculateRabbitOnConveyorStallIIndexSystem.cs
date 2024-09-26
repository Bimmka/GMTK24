using Code.Gameplay.Features.Stalls.Services;
using Entitas;

namespace Code.Gameplay.Features.Stalls
{
    public class CalculateRabbitOnConveyorStallIIndexSystem : IExecuteSystem
    {
        private readonly IStallService _stallService;
        private readonly IGroup<GameEntity> _rabbits;

        public CalculateRabbitOnConveyorStallIIndexSystem(GameContext game, IStallService stallService)
        {
            _stallService = stallService;
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.Alive,
                    GameMatcher.OnGround,
                    GameMatcher.StallParentIndex,
                    GameMatcher.OnConveyorBelt,
                    GameMatcher.WorldPosition));
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
using Entitas;

namespace Code.Gameplay.Features.Stalls
{
    public class CalculateRabbitsAmountInStallSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _stalls;
        private readonly IGroup<GameEntity> _rabbits;

        public CalculateRabbitsAmountInStallSystem(GameContext game)
        {
            _stalls = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.StallIndex,
                    GameMatcher.RabbitsAmount));

            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.Alive,
                    GameMatcher.OnGround,
                    GameMatcher.StallParentIndex));
        }

        public void Execute()
        {
            foreach (GameEntity stall in _stalls)
            {
                int rabbitsAmount = 0;
                foreach (GameEntity rabbit in _rabbits)
                {
                    if (rabbit.StallParentIndex == stall.StallIndex)
                    {
                        rabbitsAmount++;
                    }
                }

                stall.ReplaceRabbitsAmount(rabbitsAmount);
            }
        }
    }
}
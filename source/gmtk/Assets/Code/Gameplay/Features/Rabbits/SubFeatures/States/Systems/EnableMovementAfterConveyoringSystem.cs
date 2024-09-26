using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.States.Systems
{
    public class EnableMovementAfterConveyoringSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;

        public EnableMovementAfterConveyoringSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.ConveyoringFinished,
                    GameMatcher.Alive));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                rabbit.isMovementAvailable = true;
            }
        }
    }
}
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.States.Systems
{
    public class EnableWaitingMovementAfterConveyoringSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;

        public EnableWaitingMovementAfterConveyoringSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.ConveyoringFinished,
                    GameMatcher.Alive)
                .NoneOf(GameMatcher.ReplicationTarget));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                rabbit.isWaitingForMoving = true;
            }
        }
    }
}
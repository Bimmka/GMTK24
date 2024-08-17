using Entitas;

namespace Code.Gameplay.Features.Rabbits.Systems
{
    public class UpdateActivityFreeMarkSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;

        public UpdateActivityFreeMarkSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Rabbit));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                rabbit.isActivityFree = rabbit.isMoving == false && rabbit.isReplicating == false;
            }
        }
    }
}
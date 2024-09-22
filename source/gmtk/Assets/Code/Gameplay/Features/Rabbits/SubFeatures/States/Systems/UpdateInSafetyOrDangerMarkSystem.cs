using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.States.Systems
{
    public class UpdateInSafetyOrDangerMarkSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;

        public UpdateInSafetyOrDangerMarkSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.Alive));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                rabbit.isInSafety = rabbit.isOnConveyorBelt || rabbit.isReplicating || rabbit.isDragging;
                rabbit.isInDanger = rabbit.isInSafety == false;
            }
        }
    }
}
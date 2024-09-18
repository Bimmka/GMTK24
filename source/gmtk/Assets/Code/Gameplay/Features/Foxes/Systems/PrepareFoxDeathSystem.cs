using Entitas;

namespace Code.Gameplay.Features.Foxes.Systems
{
    public class PrepareFoxDeathSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _foxes;

        public PrepareFoxDeathSystem(GameContext game)
        {
            _foxes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fox,
                    GameMatcher.Dead));
        }

        public void Execute()
        {
            foreach (GameEntity fox in _foxes)
            {
                fox.isMoving = false;
                fox.isMovementAvailable = false;
                fox.isHungry = false;
                fox.isWaitingHunt = false;
                fox.isMovingToHuntTarget = false;
                fox.isDestructed = true;
            }
        }
    }
}
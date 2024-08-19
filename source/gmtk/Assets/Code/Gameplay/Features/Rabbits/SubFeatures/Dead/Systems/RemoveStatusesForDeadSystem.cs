using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Dead.Systems
{
    public class RemoveStatusesForDeadSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;
        private readonly IGroup<GameEntity> statuses;

        public RemoveStatusesForDeadSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Dead,
                    GameMatcher.Id));

            statuses = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Status,
                    GameMatcher.TargetId));
        }

        public void Execute()
        {
            foreach (GameEntity status in statuses)
            {
                foreach (GameEntity rabbit in _rabbits)
                {
                    if (status.TargetId == rabbit.Id)
                    {
                        status.isDestructed = true;
                        status.isValidStatus = false;
                    }
                }
            }
        }
    }
}
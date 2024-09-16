using Entitas;

namespace Code.Gameplay.Features.Death.Systems
{
    public class RemoveStatusesForDeadSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _deads;
        private readonly IGroup<GameEntity> statuses;

        public RemoveStatusesForDeadSystem(GameContext game)
        {
            _deads = game.GetGroup(GameMatcher
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
                foreach (GameEntity dead in _deads)
                {
                    if (status.TargetId == dead.Id)
                    {
                        status.isDestructed = true;
                        status.isValidStatus = false;
                    }
                }
            }
        }
    }
}
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Replication.Systems
{
    public class ApplyWaitingTargetVisualSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;

        public ApplyWaitingTargetVisualSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.ReplicationState,
                    GameMatcher.RabbitVisualChanger,
                    GameMatcher.Alive)
                .NoneOf(GameMatcher.Replicating));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                rabbit.RabbitVisualChanger.SetWaitTarget(rabbit.isWaitingReplicationTarget);
            }
        }
    }
}
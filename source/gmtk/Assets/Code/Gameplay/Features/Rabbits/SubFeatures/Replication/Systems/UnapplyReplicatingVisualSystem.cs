using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Replication.Systems
{
    public class UnapplyReplicatingVisualSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;

        public UnapplyReplicatingVisualSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.ReplicationFinished,
                    GameMatcher.RabbitVisualChanger));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                rabbit.RabbitVisualChanger.UnsetReplicating();
            }
        }
    }
}
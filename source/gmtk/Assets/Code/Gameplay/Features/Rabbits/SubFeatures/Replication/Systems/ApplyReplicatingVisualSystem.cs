using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Replication.Systems
{
    public class ApplyReplicatingVisualSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;

        public ApplyReplicatingVisualSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.Replicating,
                    GameMatcher.RabbitVisualChanger));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                rabbit.RabbitVisualChanger.SetReplicating();
            }
        }
    }
}
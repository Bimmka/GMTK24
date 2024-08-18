using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.StateMachine.Systems
{
    public class CleanupTransitComponentSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _rabbits;

        public CleanupTransitComponentSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.RabbitStateMachine,
                    GameMatcher.RabbitNextSimpleState,
                    GameMatcher.TransitionComplete));
        }
        
        public void Cleanup()
        {
            foreach (GameEntity rabbit in _rabbits.GetEntities())
            {
                rabbit.RemoveRabbitNextSimpleState();
            }
        }
    }
}
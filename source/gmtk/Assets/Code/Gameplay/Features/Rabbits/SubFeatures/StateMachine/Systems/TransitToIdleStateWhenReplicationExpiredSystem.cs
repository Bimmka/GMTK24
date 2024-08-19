using Code.Gameplay.Features.Rabbits.StateMachine.States;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.StateMachine.Systems
{
    public class TransitToIdleStateWhenReplicationExpiredSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _stateMachines;

        public TransitToIdleStateWhenReplicationExpiredSystem(GameContext game)
        {
            _stateMachines = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ReplicationState,
                    GameMatcher.RabbitStateMachine,
                    GameMatcher.ReplicationExpired,
                    GameMatcher.Rabbit,
                    GameMatcher.Alive));
        }

        public void Execute()
        {
            foreach (GameEntity stateMachine in _stateMachines)
            {
                stateMachine.ReplaceRabbitNextSimpleState(typeof(RabbitIdleState));
            }
        }
    }
}
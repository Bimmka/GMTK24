using Code.Gameplay.Features.Rabbits.StateMachine.States;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.StateMachine.Systems
{
    public class TransitToIdleStateWhenReplicationBlockedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _stateMachines;

        public TransitToIdleStateWhenReplicationBlockedSystem(GameContext game)
        {
            _stateMachines = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.RabbitStateMachine,
                    GameMatcher.ReplicationBlocked,
                    GameMatcher.ReplicationState,
                    GameMatcher.Rabbit,
                    GameMatcher.Alive)
                .NoneOf(GameMatcher.Replicating));
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
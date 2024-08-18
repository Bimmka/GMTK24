using Code.Gameplay.Features.Rabbits.StateMachine.States;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.StateMachine.Systems
{
    public class TransitToNewStateSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _stateMachines;

        public TransitToNewStateSystem(GameContext game)
        {
            _stateMachines = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.RabbitNextSimpleState,
                    GameMatcher.RabbitStateMachine));
        }

        public void Execute()
        {
            foreach (GameEntity stateMachine in _stateMachines)
            {
                if (stateMachine.RabbitNextSimpleState == typeof(RabbitDraggingState))
                    stateMachine.RabbitStateMachine.Enter<RabbitDraggingState>();
                else if (stateMachine.RabbitNextSimpleState == typeof(RabbitIdleState))
                    stateMachine.RabbitStateMachine.Enter<RabbitIdleState>();
                else if (stateMachine.RabbitNextSimpleState == typeof(RabbitReplicationState))
                    stateMachine.RabbitStateMachine.Enter<RabbitReplicationState>();
                else if (stateMachine.RabbitNextSimpleState == typeof(RabbitStupidMoveState))
                    stateMachine.RabbitStateMachine.Enter<RabbitStupidMoveState>();
            }
        }
    }
}
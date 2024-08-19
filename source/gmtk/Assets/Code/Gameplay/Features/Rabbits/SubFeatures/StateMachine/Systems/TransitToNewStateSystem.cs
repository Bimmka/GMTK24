using Code.Gameplay.Features.Rabbits.StateMachine.States;
using Code.Infrastructure.States.StateInfrastructure;
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
                    GameMatcher.RabbitStateMachine,
                    GameMatcher.Rabbit));
        }

        public void Execute()
        {
            foreach (GameEntity stateMachine in _stateMachines)
            {
                if (stateMachine.RabbitNextSimpleState == typeof(RabbitDraggingState))
                    EnterNewState<RabbitDraggingState>(stateMachine);
                else if (stateMachine.RabbitNextSimpleState == typeof(RabbitIdleState))
                    EnterNewState<RabbitIdleState>(stateMachine);
                else if (stateMachine.RabbitNextSimpleState == typeof(RabbitReplicationState))
                    EnterNewState<RabbitReplicationState>(stateMachine);
                else if (stateMachine.RabbitNextSimpleState == typeof(RabbitStupidMoveState))
                    EnterNewState<RabbitStupidMoveState>(stateMachine);
                else if (stateMachine.RabbitNextSimpleState == typeof(RabbitDeadState))
                    EnterNewState<RabbitDeadState>(stateMachine);
            }
        }

        private void EnterNewState<TState>(GameEntity entity) where TState : class, IState
        {
            entity.RabbitStateMachine.Enter<TState>();
            entity.isTransitionComplete = true;
        }
    }
}
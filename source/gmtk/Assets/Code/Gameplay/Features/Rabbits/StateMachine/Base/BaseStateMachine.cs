using Code.Infrastructure.States.Factory;
using Code.Infrastructure.States.StateInfrastructure;
using RSG;

namespace Code.Gameplay.Features.Rabbits.StateMachine.Base
{
    public class BaseStateMachine : IBaseStateMachine
    {
        private IExitableState _activeState;
        private readonly IStateFactory _stateFactory;
        
        public BaseStateMachine(IStateFactory stateFactory)
        {
            _stateFactory = stateFactory;
        }
        
        public void Tick()
        {
            if(_activeState is IUpdateable updateableState)
                updateableState.Update();
        }
            
        public void Enter<TState>() where TState : class, IState =>
            RequestEnter<TState>()
                .Done();
        
        private IPromise<TState> RequestEnter<TState>() where TState : class, IState =>
            RequestChangeState<TState>()
                .Then(EnterState);
            
        private TState EnterState<TState>(TState state) where TState : class, IState
        {
            _activeState = state;
        
            state.Enter();
            return state;
        }
            
        private IPromise<TState> RequestChangeState<TState>() where TState : class, IExitableState
        {
            if (_activeState != null)
            {
                return _activeState
                    .BeginExit()
                    .Then(_activeState.EndExit)
                    .Then(ChangeState<TState>);
            }
              
            return ChangeState<TState>();
        }
        
        
        private IPromise<TState> ChangeState<TState>() where TState : class, IExitableState
        {
            TState state = _stateFactory.GetState<TState>();
        
            return Promise<TState>.Resolved(state);
        }
    }
}
using Code.Infrastructure.States.StateInfrastructure;

namespace Code.Gameplay.Features.Rabbits.StateMachine.Base
{
    public interface IBaseStateMachine
    {
        void Tick();
        void Enter<TState>() where TState : class, IState;
    }
}
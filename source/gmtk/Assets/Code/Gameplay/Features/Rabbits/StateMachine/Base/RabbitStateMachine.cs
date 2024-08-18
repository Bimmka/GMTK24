using Code.Infrastructure.States.Factory;

namespace Code.Gameplay.Features.Rabbits.StateMachine.Base
{
    public class RabbitStateMachine : BaseStateMachine, IRabbitStateMachine
    {
        public RabbitStateMachine(IStateFactory stateFactory) : base(stateFactory)
        {
        }
    }
}
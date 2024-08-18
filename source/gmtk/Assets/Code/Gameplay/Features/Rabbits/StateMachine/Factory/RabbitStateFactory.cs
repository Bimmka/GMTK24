using Code.Gameplay.Features.Rabbits.StateMachine.States;
using Code.Infrastructure.States.StateInfrastructure;
using Zenject;

namespace Code.Gameplay.Features.Rabbits.StateMachine.Factory
{
    public class RabbitStateFactory : IRabbitStateFactory
    {
        private readonly DiContainer _container;
        private readonly GameEntity _rabbitEntity;

        public RabbitStateFactory(DiContainer container, GameEntity rabbitEntity)
        {
            _container = container;
            _rabbitEntity = rabbitEntity;
        }
        
        public T GetState<T>() where T : class, IExitableState
        {
            T state =  _container.Resolve<T>();

            if (state is EntitySimpleState)
                (state as EntitySimpleState).SetEntity(_rabbitEntity);

            return state;
        }
    }
}
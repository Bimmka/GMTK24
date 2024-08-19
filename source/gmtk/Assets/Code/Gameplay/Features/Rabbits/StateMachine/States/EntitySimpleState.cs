using Code.Infrastructure.States.StateInfrastructure;

namespace Code.Gameplay.Features.Rabbits.StateMachine.States
{
    public class EntitySimpleState : SimpleState
    {
        public GameEntity Entity;

        public void SetEntity(GameEntity entity)
        {
            Entity = entity;
        }
    }
}
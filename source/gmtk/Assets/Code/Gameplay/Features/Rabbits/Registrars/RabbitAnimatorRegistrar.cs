using Code.Gameplay.Features.Rabbits.Behaviours.Animations;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.Rabbits.Registrars
{
    public class RabbitAnimatorRegistrar : EntityComponentRegistrar
    {
        public RabbitAnimator RabbitAnimator;
        
        public override void RegisterComponents()
        {
            Entity.AddRabbitAnimator(RabbitAnimator);
            RabbitAnimator.Initialize(Entity.RabbitColorType);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasRabbitAnimator)
                Entity.RemoveRabbitAnimator();
        }
    }
}
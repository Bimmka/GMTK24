using Code.Gameplay.Features.Rabbits.Behaviours.Visuals;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.Rabbits.Registrars
{
    public class VisualChangerRegistrar : EntityComponentRegistrar
    {
        public RabbitVisualChanger VisualChanger;
        
        public override void RegisterComponents()
        {
            Entity.AddRabbitVisualChanger(VisualChanger);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasRabbitVisualChanger)
                Entity.RemoveRabbitVisualChanger();
        }
    }
}
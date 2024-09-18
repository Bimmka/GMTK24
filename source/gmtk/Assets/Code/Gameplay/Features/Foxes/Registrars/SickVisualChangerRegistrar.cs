using Code.Gameplay.Features.Foxes.Behaviours.Visuals;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.Foxes.Registrars
{
    public class SickVisualChangerRegistrar : EntityComponentRegistrar
    {
        public SickVisualChanger VisualChanger;
        
        public override void RegisterComponents()
        {
            Entity.AddSickVisualChanger(VisualChanger);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasSickVisualChanger)
                Entity.RemoveSickVisualChanger();
        }
    }
}
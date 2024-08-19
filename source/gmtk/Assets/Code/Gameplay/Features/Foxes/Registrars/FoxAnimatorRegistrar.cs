using Code.Gameplay.Features.Foxes.Behaviours.Animations;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.Foxes.Registrars
{
    public class FoxAnimatorRegistrar : EntityComponentRegistrar
    {
        public FoxAnimator FoxAnimator;
        
        public override void RegisterComponents()
        {
            Entity.AddFoxAnimator(FoxAnimator);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasFoxAnimator)
                Entity.RemoveFoxAnimator();
        }
    }
}
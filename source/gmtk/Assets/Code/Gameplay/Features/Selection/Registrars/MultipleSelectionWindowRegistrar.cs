using Code.Gameplay.Features.Selection.Visuals;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.Selection.Registrars
{
    public class MultipleSelectionWindowRegistrar : EntityComponentRegistrar
    {
        public MultipleSelectionWindow MultipleSelectionWindow;
        public override void RegisterComponents()
        {
            Entity.AddMultipleSelectionWindow(MultipleSelectionWindow);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasMultipleSelectionWindow)
                Entity.RemoveMultipleSelectionWindow();
        }
    }
}
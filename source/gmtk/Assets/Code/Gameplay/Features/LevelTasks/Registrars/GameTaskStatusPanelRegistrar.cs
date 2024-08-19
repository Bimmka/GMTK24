using Code.Gameplay.Windows.Windows.Game;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.LevelTasks.Registrars
{
    public class GameTaskStatusPanelRegistrar : EntityComponentRegistrar
    {
        public GameTaskStatusPanel StatusPanel;
        
        public override void RegisterComponents()
        {
            Entity.AddGameTaskStatusPanel(StatusPanel);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasGameTaskStatusPanel)
                Entity.RemoveGameTaskStatusPanel();
        }
    }
}
using Code.Gameplay.Windows.Base;

namespace Code.Gameplay.Windows.Windows.HomeScreen
{
    public class HomeScreenBackgroundWindow : BaseWindow
    {
        protected override void Initialize()
        {
            base.Initialize();
            Id = WindowId.HomeScreenBackground;
        }
    }
}
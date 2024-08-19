using UnityEngine;

namespace Code.Gameplay.Windows.Windows.HomeScreen.Factory
{
    public interface IUIGameLevelViewFactory
    {
        GameLevelView Create(RectTransform parent);
    }
}
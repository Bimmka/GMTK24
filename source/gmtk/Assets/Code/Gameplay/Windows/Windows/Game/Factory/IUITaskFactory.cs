using UnityEngine;

namespace Code.Gameplay.Windows.Windows.Game.Factory
{
    public interface IUITaskFactory
    {
        ConcreteRabbitAmountView CreateConcreteRabbitAmountView(RectTransform parent);
        RabbitTaskGoalPartView RabbitTaskGoalPartView(RectTransform parent);
        RabbitTaskGoalPartViewInGame RabbitTaskGoalPartViewInGame(RectTransform parent);
    }
}
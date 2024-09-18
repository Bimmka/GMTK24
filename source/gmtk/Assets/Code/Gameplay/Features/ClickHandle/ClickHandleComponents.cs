using Entitas;

namespace Code.Gameplay.Features.ClickHandle
{
    [Input] public class ClickedEntityId : IComponent { public int Value; }
    [Input] public class RabbitClicked : IComponent {}
    [Input] public class FoxClicked : IComponent {}
    [Input] public class EmptyClicked : IComponent {}
}
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Input.Systems
{
    public class EmitClickSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<InputEntity> _inputs;
        public EmitClickSystem(InputContext meta, ITimeService time)
        {
            _time = time;
            _inputs = meta.GetGroup(InputMatcher
                .AllOf(
                    InputMatcher.Input,
                    InputMatcher.MouseUp,
                    InputMatcher.LastMouseDownTime,
                    InputMatcher.ScreenMousePosition,
                    InputMatcher.WorldMousePosition,
                    InputMatcher.ClickInterval,
                    InputMatcher.ClickableLayerMask)
                .NoneOf(InputMatcher.Dragging));
        }

        public void Execute()
        {
            foreach (InputEntity input in _inputs)
            {
                if ((_time.Time - input.LastMouseDownTime) <= input.ClickInterval)
                {
                    CreateInputEntity
                        .Empty()
                        .AddScreenMousePosition(input.ScreenMousePosition)
                        .AddWorldMousePosition(input.WorldMousePosition)
                        .AddClickableLayerMask(input.ClickableLayerMask)
                        .With(x => x.isClick = true);
                }
            }
        }
    }
}
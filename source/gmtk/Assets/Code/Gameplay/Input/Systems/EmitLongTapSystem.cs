using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Input.Systems
{
    public class EmitLongTapSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<InputEntity> _inputs;

        public EmitLongTapSystem(InputContext meta, ITimeService time)
        {
            _time = time;
            _inputs = meta.GetGroup(InputMatcher
                .AllOf(
                    InputMatcher.Input,
                    InputMatcher.MousePressed,
                    InputMatcher.LastMouseDownTime,
                    InputMatcher.ScreenMousePosition,
                    InputMatcher.WorldMousePosition,
                    InputMatcher.LongTapInterval)
                .NoneOf(InputMatcher.Draging));
        }

        public void Execute()
        {
            foreach (InputEntity input in _inputs)
            {
                if ((_time.Time - input.LastMouseDownTime) >= input.LongTapInterval)
                {
                    CreateInputEntity
                        .Empty()
                        .AddScreenMousePosition(input.ScreenMousePosition)
                        .AddWorldMousePosition(input.WorldMousePosition)
                        .With(x => x.isLongTap = true);
                }
            }
        }
    }
}
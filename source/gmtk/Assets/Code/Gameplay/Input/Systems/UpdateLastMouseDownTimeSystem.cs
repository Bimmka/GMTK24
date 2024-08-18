using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Input.Systems
{
    public class UpdateLastMouseDownTimeSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<InputEntity> _inputs;
        public UpdateLastMouseDownTimeSystem(InputContext meta, ITimeService time)
        {
            _time = time;
            _inputs = meta.GetGroup(InputMatcher
                .AllOf(
                    InputMatcher.Input,
                    InputMatcher.MouseDown,
                    InputMatcher.LastMouseDownTime));
        }

        public void Execute()
        {
            foreach (InputEntity input in _inputs)
            {
                input.ReplaceLastMouseDownTime(_time.Time);
            }
        }
    }
}
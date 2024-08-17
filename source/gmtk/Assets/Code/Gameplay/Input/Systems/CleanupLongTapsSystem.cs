using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Input.Systems
{
    public class CleanupLongTapsSystem : ICleanupSystem
    {
        private readonly IGroup<InputEntity> _longTaps;
        private readonly List<InputEntity> _buffer = new(2);

        public CleanupLongTapsSystem(InputContext input)
        {
            _longTaps = input.GetGroup(InputMatcher.AllOf(InputMatcher.LongTap));
        }

        public void Cleanup()
        {
            foreach (InputEntity longTap in _longTaps.GetEntities(_buffer))
            {
                longTap.Destroy();
            }
        }
    }
}
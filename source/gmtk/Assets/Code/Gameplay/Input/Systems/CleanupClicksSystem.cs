using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Input.Systems
{
    public class CleanupClicksSystem : ICleanupSystem
    {
        private readonly IGroup<InputEntity> _clicks;
        private readonly List<InputEntity> _buffer = new(2);

        public CleanupClicksSystem(InputContext input)
        {
            _clicks = input.GetGroup(InputMatcher.AllOf(InputMatcher.Click));
        }

        public void Cleanup()
        {
            foreach (InputEntity click in _clicks.GetEntities(_buffer))
            {
                click.Destroy();
            }
        }
    }
}
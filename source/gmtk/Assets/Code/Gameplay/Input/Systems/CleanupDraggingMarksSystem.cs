using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Input.Systems
{
    public class CleanupDraggingMarksSystem : ICleanupSystem
    {
        private readonly IGroup<InputEntity> _inputs;
        private readonly List<InputEntity> _buffer = new List<InputEntity>(1);

        public CleanupDraggingMarksSystem(InputContext meta)
        {
            _inputs = meta.GetGroup(InputMatcher
                .AllOf(
                    InputMatcher.Input,
                    InputMatcher.MouseUp,
                    InputMatcher.WasDragging,
                    InputMatcher.Dragging));
        }

        public void Cleanup()
        {
            foreach (InputEntity input in _inputs.GetEntities(_buffer))
            {
                input.isWasDragging = false;
                input.isDragging = false;
            }
        }
    }
}
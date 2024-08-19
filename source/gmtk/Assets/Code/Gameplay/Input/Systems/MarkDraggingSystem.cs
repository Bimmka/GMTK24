using Entitas;
using UnityEngine;

namespace Code.Gameplay.Input.Systems
{
    public class MarkDraggingSystem : IExecuteSystem
    {
        private readonly IGroup<InputEntity> _inputs;
        
        public MarkDraggingSystem(InputContext meta)
        {
            _inputs = meta.GetGroup(InputMatcher
                .AllOf(
                    InputMatcher.Input,
                    InputMatcher.WorldMousePosition,
                    InputMatcher.StartMouseDownWorldPosition,
                    InputMatcher.PositionShiftForDragStart));
        }

        public void Execute()
        {
            foreach (InputEntity input in _inputs)
            {
                if (input.isMousePressed)
                    input.isDragging = Vector3.SqrMagnitude(input.WorldMousePosition - input.StartMouseDownWorldPosition) >= input.PositionShiftForDragStart;
                else
                    input.isDragging = false;
            }
        }
    }
}
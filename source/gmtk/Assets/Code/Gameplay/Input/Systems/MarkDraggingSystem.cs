using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Input.Systems
{
    public class MarkDraggingSystem : IExecuteSystem
    {
        private readonly IGroup<InputEntity> _inputs;
        private readonly List<InputEntity> _buffer = new List<InputEntity>(1);

        public MarkDraggingSystem(InputContext meta)
        {
            _inputs = meta.GetGroup(InputMatcher
                .AllOf(
                    InputMatcher.Input,
                    InputMatcher.WorldMousePosition,
                    InputMatcher.StartMouseDownWorldPosition,
                    InputMatcher.PositionShiftForDragStart,
                    InputMatcher.MousePressed)
                .NoneOf(InputMatcher.Dragging));
        }

        public void Execute()
        {
            foreach (InputEntity input in _inputs.GetEntities(_buffer))
            {
                input.isDragging = Vector3.SqrMagnitude(input.WorldMousePosition - input.StartMouseDownWorldPosition) >= input.PositionShiftForDragStart;
            }
        }
    }
}
﻿using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Selection
{
    [Game] public class Selectable : IComponent {}
    [Game] public class Selected : IComponent {}
    [Game] public class SelectedEntities : IComponent { public List<int> Value; }
    [Game] public class SelectionLayerMask : IComponent { public LayerMask Value; }
    [Game] public class HasSelections : IComponent { }
    [Game] public class Dragging : IComponent { }
    [Game] public class DragCanceled : IComponent {}
    [Game] public class MovingToAfterDragPosition : IComponent {}
    [Game] public class SavedPositionBeforeDrag : IComponent { public Vector3 Value; }
    [Game] public class AfterDragPosition : IComponent { public Vector3 Value; }
    [Game] public class FollowSelectCenterSpeed : IComponent { public float Value; }
    [Game] public class MoveToAfterDragPositionSpeed : IComponent { public float Value; }
    [Game] public class SelectCenterPosition : IComponent { public Vector3 Value; }
    [Game] public class ShiftFromSelect : IComponent { public Vector3 Value; }
    [Game] public class SelectCenterRadius : IComponent { public float Value; }
    [Game] public class DragFinished : IComponent {}
}
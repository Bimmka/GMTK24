using System.Collections.Generic;
using Code.Gameplay.Features.Selection.Visuals;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Selection
{
    [Game] public class Selection : IComponent {}
    [Game] public class Selectable : IComponent {}
    [Game] public class Selected : IComponent {}
    [Game] public class SelectedEntities : IComponent { public List<int> Value; }
    [Game] public class EntitiesForSelectionQueue : IComponent { public Queue<int> Value; }
    [Game] public class SelectionLayerMask : IComponent { public LayerMask Value; }
    [Game] public class HasSelections : IComponent { }
    [Game] public class Dragging : IComponent { }
    [Game] public class DragCanceled : IComponent {}
    [Game] public class DragFinished : IComponent {}
    [Game] public class UnselectSelectedEntities : IComponent {}
    [Game] public class CleanupUnselectMark : IComponent {}
    [Game] public class MovingToAfterDragPosition : IComponent {}
    [Game] public class SavedPositionBeforeDrag : IComponent { public Vector3 Value; }
    [Game] public class AfterDragPosition : IComponent { public Vector3 Value; }
    [Game] public class FollowSelectCenterSpeed : IComponent { public float Value; }
    [Game] public class MoveToAfterDragPositionSpeed : IComponent { public float Value; }
    [Game] public class SelectCenterPosition : IComponent { public Vector3 Value; }
    [Game] public class ShiftFromSelect : IComponent { public Vector3 Value; }
    [Game] public class SelectCenterRadius : IComponent { public float Value; }
    [Game] public class WaitingMouseDragFinish: IComponent {}
    [Game] public class StoppedWaitingMouseDragFinish : IComponent {}
    [Game] public class DragStarted : IComponent {}
    [Game] public class DragStopped : IComponent {}
    [Game] public class MultipleSelectionWindowComponent : IComponent { public MultipleSelectionWindow Value; }
}
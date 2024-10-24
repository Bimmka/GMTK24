using Code.Gameplay.Features.Selection.SubFeatures.DragSelections.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Selection.SubFeatures.DragSelections
{
    public sealed class DragSelectionsFeature : Feature
    {
        public DragSelectionsFeature(ISystemFactory systems)
        {
            //Add(systems.Create<StartDragByClick>());
            Add(systems.Create<StartDragByMultipleSelectionSystem>());
            
            Add(systems.Create<StopDragAfterEmptyMouseClickSystem>());
            Add(systems.Create<StopDragAfterConveyorBeltMouseClickSystem>());
            Add(systems.Create<SetPositionToSelectedEntitiesWhenCancelDraggingSystem>());
            Add(systems.Create<CancelDraggingSystem>());
        }
    }
}
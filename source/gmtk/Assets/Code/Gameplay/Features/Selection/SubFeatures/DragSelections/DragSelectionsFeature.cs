using Code.Gameplay.Features.Selection.SubFeatures.DragSelections.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Selection.SubFeatures.DragSelections
{
    public sealed class DragSelectionsFeature : Feature
    {
        public DragSelectionsFeature(ISystemFactory systems)
        {
            Add(systems.Create<StartDragByClick>());
            Add(systems.Create<StartDragByMultipleSelectionSystem>());
            
            Add(systems.Create<StopDragAfterMouseClickSystem>());
            Add(systems.Create<CancelDraggingSystem>());
        }
    }
}
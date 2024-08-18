using Code.Gameplay.Features.Selection.SubFeatures.DragSelections.Systems;
using Code.Gameplay.Features.Selection.SubFeatures.MoveSelected.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Selection.SubFeatures.DragSelections
{
    public sealed class DragSelectionsFeature : Feature
    {
        public DragSelectionsFeature(ISystemFactory systems)
        {
            Add(systems.Create<StartDragByLongTap>());
            Add(systems.Create<StopDragAfterMouseUpSystem>());
            Add(systems.Create<CancelDraggingSystem>());

            Add(systems.Create<MoveToAfterDragPositionSystem>());
        }
    }
}
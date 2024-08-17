using Code.Gameplay.Features.Selection.SubFeatures.DragSelections;
using Code.Gameplay.Features.Selection.SubFeatures.MoveSelected;
using Code.Gameplay.Features.Selection.SubFeatures.SelectionCenter;
using Code.Gameplay.Features.Selection.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Selection
{
    public sealed class SelectionFeature : Feature
    {
        public SelectionFeature(ISystemFactory systems)
        {
            Add(systems.Create<InitializeSelectionSystem>());
            
            Add(systems.Create<MarkWaitingMouseDragFinishSystem>());
            Add(systems.Create<SelectByClickSystem>());
            Add(systems.Create<SelectByMouseDraggingSystem>());
            
            Add(systems.Create<ClearSelectedEntitiesWhenUnselectSystem>());
            Add(systems.Create<AddSelectedEntitiesFromQueueSystem>());
            Add(systems.Create<RefreshHasSelectedMarkSystem>());

            Add(systems.Create<DragSelectionsFeature>());
            Add(systems.Create<SelectionCenterFeature>());
            Add(systems.Create<MoveSelectedFeature>());

            Add(systems.Create<RemoveUnselectMarkFromSelectionSystem>());
        }
    }
}
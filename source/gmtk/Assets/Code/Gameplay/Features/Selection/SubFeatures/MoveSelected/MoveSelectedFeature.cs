using Code.Gameplay.Features.Selection.SubFeatures.MoveSelected.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Selection.SubFeatures.MoveSelected
{
    public sealed class MoveSelectedFeature : Feature
    {
        public MoveSelectedFeature(ISystemFactory systems)
        {
            Add(systems.Create<MoveSelectedFollowToSelectionCenterSystem>());
            Add(systems.Create<MoveToAfterDragPositionSystem>());
            Add(systems.Create<FinishMoveAfterDraggingSystem>());
        }
    }
}
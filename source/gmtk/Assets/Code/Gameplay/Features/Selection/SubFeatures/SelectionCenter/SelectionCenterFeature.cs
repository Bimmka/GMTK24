using Code.Gameplay.Features.Selection.SubFeatures.SelectionCenter.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Selection.SubFeatures.SelectionCenter
{
    public sealed class SelectionCenterFeature : Feature
    {
        public SelectionCenterFeature(ISystemFactory systems)
        {
            Add(systems.Create<UpdateSelectionCenterPositionSystem>());
        }
    }
}
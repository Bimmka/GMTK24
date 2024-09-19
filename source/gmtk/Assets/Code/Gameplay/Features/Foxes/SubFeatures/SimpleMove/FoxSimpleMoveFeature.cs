using Code.Gameplay.Features.Foxes.SubFeatures.SimpleMove.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Foxes.SubFeatures.SimpleMove
{
    public sealed class FoxSimpleMoveFeature : Feature
    {
        public FoxSimpleMoveFeature(ISystemFactory systems)
        {
            Add(systems.Create<UpdateNextMovingTimeLeftSystem>());
            Add(systems.Create<MarkMovingUpSystem>());
            Add(systems.Create<StartMovingToRandomPointSystem>());
            Add(systems.Create<StopMovingToReachedTargetPointSystem>());
        }
    }
}
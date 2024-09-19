using Code.Gameplay.Features.Foxes.SubFeatures.Death;
using Code.Gameplay.Features.Foxes.SubFeatures.Hunt;
using Code.Gameplay.Features.Foxes.SubFeatures.SimpleMove;
using Code.Gameplay.Features.Foxes.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Foxes
{
    public sealed class FoxFeature : Feature
    {
        public FoxFeature(ISystemFactory systems)
        {
            Add(systems.Create<FoxSimpleMoveFeature>());
            Add(systems.Create<FoxHuntFeature>());
            Add(systems.Create<FoxDeathFeature>());
            
            Add(systems.Create<RemoveMarkInvalidTargetSystem>());
            Add(systems.Create<RemoveMarkMovingUpSystem>());

            Add(systems.Create<RemoveEatingMarksSystem>());

            Add(systems.Create<CleanupHuntHuntSoundWhenHuntFinished>());
            Add(systems.Create<CleanupHuntTargetWhenHuntFinished>());
            
            Add(systems.Create<CleanupMarkHuntStartedSystem>());
            Add(systems.Create<CleanupMarkHuntFinishedSystem>());
        }
    }
}
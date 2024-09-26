using Code.Gameplay.Features.Rabbits.SubFeatures.Conveyor.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Conveyor
{
    public sealed class RabbitConveyorFeature : Feature
    {
        public RabbitConveyorFeature(ISystemFactory systems)
        {
            Add(systems.Create<CleanupConveyoringStartedSystem>());
            Add(systems.Create<CleanupConveyorComponentsWhenConveyoringFinishedSystem>());
        }
    }
}
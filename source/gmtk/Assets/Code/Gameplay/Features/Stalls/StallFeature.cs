using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Stalls
{
    public sealed class StallFeature : Feature
    {
        public StallFeature(ISystemFactory systems)
        {
            Add(systems.Create<CalculateRabbitOnConveyorStallIIndexSystem>());

            Add(systems.Create<CalculateRabbitsAmountInStallSystem>());
        }
    }
}
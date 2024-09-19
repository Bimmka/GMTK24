using Code.Gameplay.Features.Foxes.SubFeatures.Death.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Foxes.SubFeatures.Death
{
    public sealed class FoxDeathFeature : Feature
    {
        public FoxDeathFeature(ISystemFactory systems)
        {
            Add(systems.Create<PrepareFoxDeathSystem>());
            Add(systems.Create<FoxDeathByPoisonSystem>());
            Add(systems.Create<FoxDeathByRabiesSystem>());
        }
    }
}
using Code.Gameplay.Features.Rabbits.SubFeatures.Death.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Death
{
    public sealed class RabbitDeathFeature : Feature
    {
        public RabbitDeathFeature(ISystemFactory systems)
        {
            Add(systems.Create<PrepareForDeathSystem>());
            Add(systems.Create<DeathByEatenSystem>());
            
            Add(systems.Create<DeathByRabiesSystem>());
            Add(systems.Create<DeathByEatenSystem>());
            Add(systems.Create<DeathByPoisonSystem>());
        }
    }
}
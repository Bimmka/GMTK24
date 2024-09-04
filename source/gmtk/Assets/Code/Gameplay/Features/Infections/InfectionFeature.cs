using Code.Gameplay.Features.Infections.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Infections
{
    public sealed class InfectionFeature : Feature
    {
        public InfectionFeature(ISystemFactory systems)
        {
            Add(systems.Create<ValidateInfectionByCarrierSystem>());

            Add(systems.Create<UpdateTimeLeftBeforeInfectionSystem>());
            Add(systems.Create<MarkInfectionUpSystem>());
            
            Add(systems.Create<InfectByLevelPoisonInfectionSystem>());
            Add(systems.Create<InfectByPoisonInfectionSystem>());
            
            Add(systems.Create<InfectByLevelRabiesInfectionSystem>());
            Add(systems.Create<InfectByRabiesInfectionSystem>());

            Add(systems.Create<RestartInfectionTimeLeftSystem>());
            
            Add(systems.Create<RemoveMarkInfectionUpSystem>());
        }
    }
}
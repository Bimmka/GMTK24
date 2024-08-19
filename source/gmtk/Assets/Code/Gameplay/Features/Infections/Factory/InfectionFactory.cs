using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Infections.Configs;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.Infections.Factory
{
    public class InfectionFactory : IInfectionFactory
    {
        private readonly IIdentifierService _identifierService;

        public InfectionFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateInfection(InfectionSetup setup, int carrierId)
        {
            switch (setup.Type)
            {
                case InfectionType.PoisonInfection:
                    return CreatePoisonInfection(setup, carrierId);
                case InfectionType.RabiesInfection:
                    return CreateRabiesInfection(setup, carrierId);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public GameEntity CreateLevelInfection(InfectionType infectionType, float interval)
        {
            switch (infectionType)
            {
                case InfectionType.PoisonInfection:
                    return CreateDefaultLevelInfection(infectionType, interval)
                        .With(x => x.isPoisoningInfection = true);
                case InfectionType.RabiesInfection:
                    return CreateDefaultLevelInfection(infectionType, interval)
                        .With(x => x.isRabiesInfection = true);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private GameEntity CreatePoisonInfection(InfectionSetup setup, int carrierId)
        {
            return CreateDefaultInfection(setup, carrierId)
                    .AddRadius(setup.Radius)
                    .With(x => x.isPoisoningInfection = true)
                ;
        }

        private GameEntity CreateRabiesInfection(InfectionSetup setup, int carrierId)
        {
            return CreateDefaultInfection(setup, carrierId)
                    .AddInfectionTrayLength(setup.TrayLength)
                    .AddInfectionTrayWidth(setup.TrayWidth)
                    .With(x => x.isRabiesInfection = true)
                ;
        }

        private GameEntity CreateDefaultLevelInfection(InfectionType infectionType, float interval)
        {
            return CreateEntity
                .Empty()
                .AddId(_identifierService.Next())
                .AddInfectionInterval(interval)
                .AddTimeLeftBeforeInfection(interval)
                .AddInfectionType(infectionType)
                .With(x => x.isInfection = true)
                .With(x => x.isValidInfection = true)
                .With(x => x.isLevelInfection = true)
                ;
        }

        public GameEntity CreateDefaultInfection(InfectionSetup setup, int carrierId)
        {
            return CreateEntity
                    .Empty()
                    .AddId(_identifierService.Next())
                    .AddInfectionType(setup.Type)
                    .AddCarrierOfInfectionId(carrierId)
                    .AddInfectionInterval(setup.InfectPeriod)
                    .AddTimeLeftBeforeInfection(setup.InfectPeriod)
                    .AddChanceToInfect(setup.ChanceToInfect)
                    .AddInfectionLayerMask(setup.InfectMask)
                    .AddDuration(setup.TimeBeforeDeath)
                    .With(x => x.isInfection = true)
                    .With(x => x.isValidInfection = true)
                ;
        }
    }
}
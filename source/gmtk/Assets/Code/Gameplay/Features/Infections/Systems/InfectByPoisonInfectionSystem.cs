using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Common.Physics;
using Code.Gameplay.Common.Random;
using Code.Gameplay.Features.Infections.Configs;
using Code.Gameplay.Features.Infections.Factory;
using Code.Gameplay.Features.Statuses;
using Code.Gameplay.Features.Statuses.Applier;
using Code.Gameplay.StaticData;
using Entitas;

namespace Code.Gameplay.Features.Infections.Systems
{
    public class InfectByPoisonInfectionSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IPhysicsService _physicsService;
        private readonly IRandomService _randomService;
        private readonly IStatusApplier _statusApplier;
        private readonly IStaticDataService _staticDataService;
        private readonly IInfectionFactory _infectionFactory;
        private readonly IGroup<GameEntity> _infections;
        private readonly IGroup<GameEntity> _rabbits;

        public InfectByPoisonInfectionSystem(
            GameContext game,
            IPhysicsService physicsService,
            IRandomService randomService,
            IStatusApplier statusApplier,
            IStaticDataService staticDataService,
            IInfectionFactory infectionFactory)
        {
            _game = game;
            _physicsService = physicsService;
            _randomService = randomService;
            _statusApplier = statusApplier;
            _staticDataService = staticDataService;
            _infectionFactory = infectionFactory;
            _infections = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.PoisoningInfection,
                    GameMatcher.Radius,
                    GameMatcher.ChanceToInfect,
                    GameMatcher.InfectionLayerMask,
                    GameMatcher.InfectionUp,
                    GameMatcher.CarrierOfInfectionId,
                    GameMatcher.ValidInfection));
        }

        public void Execute()
        {
            foreach (GameEntity infection in _infections)
            {
                GameEntity infectionCarrier = _game.GetEntityWithId(infection.CarrierOfInfectionId);

                IEnumerable<GameEntity> rabbits = _physicsService.CircleCast(infectionCarrier.WorldPosition, infection.Radius, infection.InfectionLayerMask);

                foreach (GameEntity rabbit in rabbits)
                {
                    if (rabbit.isCarrierOfPoisonInfection)
                        continue;

                    float randomValue = _randomService.Range(0, 1f);
                    
                    if (randomValue > infection.ChanceToInfect)
                        continue;

                    var setup = _staticDataService.GetInfectionConfig(InfectionType.PoisonInfection).InfectionSetup;

                    _statusApplier.ApplyStatus(new StatusSetup()
                    {
                        StatusType = StatusTypeId.Poison,
                        Duration = setup.TimeBeforeDeath,
                        Value = setup.EffectValue
                    }, rabbit.Id);

                    _infectionFactory.CreateInfection(setup, rabbit.Id);
                }
            }
        }
    }
}
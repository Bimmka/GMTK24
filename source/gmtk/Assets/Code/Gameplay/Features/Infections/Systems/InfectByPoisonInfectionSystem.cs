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

                IEnumerable<GameEntity> possibleContagious = _physicsService.CircleCast(infectionCarrier.WorldPosition, infection.Radius, infection.InfectionLayerMask);

                foreach (GameEntity contagious in possibleContagious)
                {
                    if (contagious.Id == infection.CarrierOfInfectionId)
                        continue;
                    
                    if (contagious.isCarrierOfPoisonInfection)
                        continue;
                    
                    if (contagious.isCanBeInfectedByPoison == false)
                        continue;

                    float randomValue = _randomService.Range(0, 1f);
                    
                    if (randomValue > infection.ChanceToInfect)
                        continue;

                    var setup = _staticDataService.GetInfectionConfig(InfectionType.PoisonInfection, contagious.isRabbit ? InfectionTargetType.Rabbit : InfectionTargetType.Fox).InfectionSetup;

                    _statusApplier.ApplyStatus(new StatusSetup()
                    {
                        StatusType = StatusTypeId.Poison,
                        Duration = setup.TimeBeforeDeath,
                    }, contagious.Id);

                    _infectionFactory.CreateInfection(setup, contagious.Id);
                }
            }
        }
    }
}
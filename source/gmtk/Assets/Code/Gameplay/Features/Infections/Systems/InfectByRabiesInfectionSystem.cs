using System.Collections.Generic;
using Code.Gameplay.Common.Physics;
using Code.Gameplay.Common.Random;
using Code.Gameplay.Features.Infections.Configs;
using Code.Gameplay.Features.Infections.Factory;
using Code.Gameplay.Features.Statuses;
using Code.Gameplay.Features.Statuses.Applier;
using Code.Gameplay.StaticData;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Infections.Systems
{
    public class InfectByRabiesInfectionSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IPhysicsService _physicsService;
        private readonly IRandomService _randomService;
        private readonly IStatusApplier _statusApplier;
        private readonly IStaticDataService _staticDataService;
        private readonly IInfectionFactory _infectionFactory;
        private readonly IGroup<GameEntity> _infections;
        private readonly IGroup<GameEntity> _rabbits;

        public InfectByRabiesInfectionSystem(
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
                    GameMatcher.RabiesInfection,
                    GameMatcher.InfectionTrayLength,
                    GameMatcher.InfectionTrayWidth,
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
                IEnumerable<GameEntity> rabbits;

                Vector2 boxCastSize = new Vector2(infection.InfectionTrayWidth, infection.InfectionTrayLength) / 2;

                if (infectionCarrier.isMoving)
                {
                    float angle = Vector2.SignedAngle(infectionCarrier.MoveDirection, Vector2.right);
                    rabbits = _physicsService.BoxCast(
                        infectionCarrier.WorldPosition,
                        boxCastSize, 
                        angle, 
                        infectionCarrier.MoveDirection * -1,
                        infection.InfectionTrayLength,
                        infection.InfectionLayerMask);
                }
                else
                {
                    rabbits = _physicsService.BoxCast(
                        infectionCarrier.WorldPosition,
                        boxCastSize, 
                        0, 
                        Vector2.zero,
                        0,
                        infection.InfectionLayerMask);
                }

                foreach (GameEntity rabbit in rabbits)
                {
                    if (rabbit.Id == infection.CarrierOfInfectionId)
                        continue;
                    
                    if (rabbit.isCarrierOfRabiesInfection)
                        continue;

                    float randomValue = _randomService.Range(0, 1f);
                    
                    if (randomValue > infection.ChanceToInfect)
                        continue;

                    var setup = _staticDataService.GetInfectionConfig(InfectionType.RabiesInfection).InfectionSetup;

                    _statusApplier.ApplyStatus(new StatusSetup()
                    {
                        StatusType = StatusTypeId.Rabies,
                        Duration = setup.TimeBeforeDeath,
                    }, rabbit.Id);

                    _infectionFactory.CreateInfection(setup, rabbit.Id);
                }
            }
        }
    }
}
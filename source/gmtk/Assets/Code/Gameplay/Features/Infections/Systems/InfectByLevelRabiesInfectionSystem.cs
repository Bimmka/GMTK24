﻿using System.Linq;
using Code.Gameplay.Features.Infections.Configs;
using Code.Gameplay.Features.Infections.Factory;
using Code.Gameplay.Features.Statuses;
using Code.Gameplay.Features.Statuses.Applier;
using Code.Gameplay.StaticData;
using Entitas;

namespace Code.Gameplay.Features.Infections.Systems
{
    public class InfectByLevelRabiesInfectionSystem : IExecuteSystem
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IStatusApplier _statusApplier;
        private readonly IInfectionFactory _infectionFactory;
        private readonly IGroup<GameEntity> _infections;
        private readonly IGroup<GameEntity> _rabbits;

        public InfectByLevelRabiesInfectionSystem(
            GameContext game,
            IStaticDataService staticDataService,
            IStatusApplier statusApplier,
            IInfectionFactory infectionFactory)
        {
            _staticDataService = staticDataService;
            _statusApplier = statusApplier;
            _infectionFactory = infectionFactory;
            _infections = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.RabiesInfection,
                    GameMatcher.LevelInfection,
                    GameMatcher.InfectionUp,
                    GameMatcher.ValidInfection));

            _rabbits = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Rabbit)
                .NoneOf(GameMatcher.CarrierOfRabiesInfection));
        }

        public void Execute()
        {
            foreach (GameEntity infection in _infections)
            {
                if (_rabbits.count > 0)
                {
                    GameEntity rabbit = _rabbits.AsEnumerable().First();

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
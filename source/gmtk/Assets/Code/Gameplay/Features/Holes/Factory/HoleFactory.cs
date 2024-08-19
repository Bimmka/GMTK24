using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Common.Random;
using Code.Gameplay.Features.Holes.Config;
using Code.Gameplay.Levels;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Holes.Factory
{
    public class HoleFactory : IHoleFactory
    {
        private readonly IRandomService _randomService;
        private readonly IIdentifierService _identifierService;
        private readonly ILevelDataProvider _levelDataProvider;

        public HoleFactory(IRandomService randomService, IIdentifierService identifierService, ILevelDataProvider levelDataProvider)
        {
            _randomService = randomService;
            _identifierService = identifierService;
            _levelDataProvider = levelDataProvider;
        }
        
        public GameEntity Create(HoleSetup setup, Vector3 at, int stallIndex)
        {
            float randomSpawnInterval = _randomService.Range(setup.MinSpawnInterval, setup.MaxSpawnInterval);

            List<HoleEntitySpawnData> entitySpawnData = new List<HoleEntitySpawnData>(setup.HoleEntityConfigSpawnData.Length);

            foreach (HoleEntityConfigSpawnData configSpawnData in setup.HoleEntityConfigSpawnData)
            {
                entitySpawnData.Add(new HoleEntitySpawnData()
                {
                    SpawnType = configSpawnData.SpawnType,
                    RabbitColorTypes = configSpawnData.RabbitColorTypes,
                    Chance = _randomService.Range(configSpawnData.MinChance, configSpawnData.MaxChance)
                });
            }

            return CreateEntity
                .Empty()
                .AddId(_identifierService.Next())
                .AddWorldPosition(at)
                .AddStallParentIndex(stallIndex)
                .AddSpawnInterval(randomSpawnInterval)
                .AddSpawnTimeLeft(randomSpawnInterval)
                .AddHoleEntitySpawnData(entitySpawnData)
                .AddParentTransform(_levelDataProvider.HoleSpawnParent)
                .AddViewPrefab(setup.View)
                .With(x => x.isHole = true)
                ;
        }
    }
}
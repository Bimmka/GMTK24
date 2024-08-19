using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Common.Random;
using Code.Gameplay.Features.CharacterStats;
using Code.Gameplay.Features.Foxes.Config;
using Code.Gameplay.Levels;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Foxes.Factory
{
    public class FoxFactory : IFoxFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly ILevelDataProvider _levelDataProvider;
        private readonly IIdentifierService _identifierService;
        private readonly IRandomService _randomService;

        public FoxFactory(
            IStaticDataService staticDataService,
            ILevelDataProvider levelDataProvider,
            IIdentifierService identifierService,
            IRandomService randomService)
        {
            _staticDataService = staticDataService;
            _levelDataProvider = levelDataProvider;
            _identifierService = identifierService;
            _randomService = randomService;
        }
        
        public GameEntity Create(Vector3 at, int stallIndex)
        {
            FoxConfig foxConfig = _staticDataService.GetFoxConfig();
            
            float randomSpeed = _randomService.Range(foxConfig.MinSpeed, foxConfig.MaxSpeed);
            float randomHuntDuration = _randomService.Range(foxConfig.MinHuntDuration, foxConfig.MaxHuntDuration);
            int randomRabbitAmountToGetEnough = _randomService.Range(foxConfig.MinRabbitsToGetEnough, foxConfig.MaxRabbitsToGetEnough);
            float randomMovingInterval = _randomService.Range(foxConfig.MinIntervalBetweenMoving, foxConfig.MaxIntervalBetweenMoving);
            float randomDragReleaseDuration = _randomService.Range(foxConfig.MinDragReleaseDuration, foxConfig.MaxDragReleaseDuration);
            float randomBeforeNextHuntInterval = _randomService.Range(foxConfig.MinBeforeNextHuntInterval, foxConfig.MaxBeforeNextHuntInterval);


            Dictionary<Stats, float> baseStats = InitStats.EmptyFoxStatDictionary()
                    .With(x => x[Stats.Speed] = randomSpeed)
                    .With(x => x[Stats.HuntDuration] = randomHuntDuration)
                    .With(x => x[Stats.RabbitToGetEnough] = randomRabbitAmountToGetEnough)
                    .With(x => x[Stats.MovingInterval] = randomMovingInterval)
                    .With(x => x[Stats.DragReleaseDuration] = randomDragReleaseDuration)
                    .With(x => x[Stats.BeforeNextHuntInterval] = randomBeforeNextHuntInterval);
            
            return CreateEntity
                .Empty()
                .AddId(_identifierService.Next())
                .AddBaseStats(baseStats)
                .AddStatModifiers(InitStats.EmptyFoxStatDictionary())
                .AddMovingInterval(randomMovingInterval)
                .AddTimeLeftForMoving(0)
                .AddWorldPosition(at)
                .AddStallParentIndex(stallIndex)
                .AddViewPrefab(foxConfig.View)
                .AddParentTransform(_levelDataProvider.FoxSpawnParent)
                .AddSpeed(randomSpeed)
                .AddSelectionDragMaxTime(randomDragReleaseDuration)
                .AddSelectionDragTimeLeft(randomDragReleaseDuration)
                .AddHuntDuration(randomHuntDuration)
                .AddHuntTimeLeft(randomHuntDuration)
                .AddEatingDuration(foxConfig.EatingTime)
                .AddEatingTimeLeft(foxConfig.EatingTime)
                .AddTargetAmountToGetEnough(randomRabbitAmountToGetEnough)
                .AddTargetAmountGot(0)
                .AddBeforeNextHuntInterval(randomBeforeNextHuntInterval)
                .AddBeforeNextHuntTimeLeft(randomBeforeNextHuntInterval)
                .With(x => x.isFox = true)
                .With(x => x.isTurnedAlongDirection = true)
                .With(x => x.isMovementAvailable = true)
                .With(x => x.isAlive = true)
                .With(x => x.isWaitingForMoving = true)
                .With(x => x.isWaitingHunt = true)
                .With(x => x.isWaitingNextHuntTarget = true)
                ;
        }
    }
}
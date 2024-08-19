using System;
using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Common.Random;
using Code.Gameplay.Features.CharacterStats;
using Code.Gameplay.Features.Rabbits.Config;
using Code.Gameplay.Features.Rabbits.Config.Rabbits;
using Code.Gameplay.Features.Rabbits.StateMachine.Base;
using Code.Gameplay.Features.Rabbits.StateMachine.Factory;
using Code.Gameplay.Features.Rabbits.StateMachine.States;
using Code.Gameplay.Levels;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.Rabbits.Factory
{
    public class RabbitFactory : IRabbitFactory
    {
        private readonly DiContainer _container;
        private readonly IStaticDataService _staticDataService;
        private readonly ILevelDataProvider _levelDataProvider;
        private readonly IIdentifierService _identifierService;
        private readonly IRandomService _randomService;

        public RabbitFactory(
            DiContainer container,
            IStaticDataService staticDataService,
            ILevelDataProvider levelDataProvider,
            IIdentifierService identifierService,
            IRandomService randomService)
        {
            _container = container;
            _staticDataService = staticDataService;
            _levelDataProvider = levelDataProvider;
            _identifierService = identifierService;
            _randomService = randomService;
        }

        public GameEntity Create(RabbitColorType type, Vector3 at, int stallIndex)
        {
            RabbitConfig config = _staticDataService.GetRabbitConfig(type);

            return SimpleRabbit(config, at, stallIndex);
        }

        private GameEntity SimpleRabbit(RabbitConfig rabbitConfig, Vector3 at, int stallIndex)
        {
            GameEntity rabbitEntity = CreateEntity
                .Empty();
            
            IRabbitStateFactory stateFactory = new RabbitStateFactory(_container, rabbitEntity);
            RabbitStateMachine stateMachine = new RabbitStateMachine(stateFactory);

            float intervalBeforeNextReplication = _randomService.Range(rabbitConfig.MinIntervalBetweenReplication,
                rabbitConfig.MaxIntervalBetweenReplication);

            float randomSpeed = _randomService.Range(rabbitConfig.MinSpeed, rabbitConfig.MaxSpeed);
            float randomReplicationDuration = _randomService.Range(rabbitConfig.MinReplicationDuration, rabbitConfig.MaxReplicationDuration);
            float randomDragReleaseDuration = _randomService.Range(rabbitConfig.MinTimeToReleaseFromDrag, rabbitConfig.MaxTimeToReleaseFromDrag);
            float randomIntervalBetweenMoving = _randomService.Range(rabbitConfig.MinIntervalBetweenMoving, rabbitConfig.MaxIntervalBetweenMoving);
            float randomWaitReplicationDuration = _randomService.Range(rabbitConfig.MinWaitReplicationDuration, rabbitConfig.MaxWaitReplicationDuration);

            Dictionary<Stats, float> baseStats = InitStats.EmptyRabbitStatDictionary()
                .With(x => x[Stats.Speed] = randomSpeed)
                .With(x => x[Stats.ReplicationDuration] = randomReplicationDuration)
                .With(x => x[Stats.DragReleaseDuration] = randomDragReleaseDuration)
                .With(x => x[Stats.MovingInterval] = randomIntervalBetweenMoving)
                ;
            
            rabbitEntity
                .AddId(_identifierService.Next())
                .AddRabbitColorType(rabbitConfig.ColorType)
                .AddDefaultReplicationDuration(randomReplicationDuration)
                .AddCurrentReplicationDuration(randomReplicationDuration)
                .AddReplicationInterval(intervalBeforeNextReplication)
                .AddReplicationTimeLeft(randomReplicationDuration)
                .AddTimeLeftForNextReplication(intervalBeforeNextReplication)
                .AddMovingInterval(randomIntervalBetweenMoving)
                .AddTimeLeftForMoving(0)
                .AddWorldPosition(at)
                .AddStallParentIndex(stallIndex)
                .AddViewPrefab(rabbitConfig.View)
                .AddParentTransform(_levelDataProvider.RabbitSpawnParent)
                .AddSpeed(randomSpeed)
                .AddSelectionDragMaxTime(randomDragReleaseDuration)
                .AddSelectionDragTimeLeft(randomDragReleaseDuration)
                .AddRabbitStateMachine(stateMachine)
                .AddWaitReplicationDuration(randomWaitReplicationDuration)
                .AddWaitReplicationTimeLeft(randomWaitReplicationDuration)
                .AddBaseStats(baseStats)
                .AddStatModifiers(InitStats.EmptyRabbitStatDictionary())
                .With(x => x.isRabbit = true)
                .With(x => x.isSaveRotationInSpawn = true)
                .With(x => x.isTurnedAlongDirection = true)
                .With(x => x.isIdleState = true)
                .With(x => x.isSelectable = true)
                .With(x => x.isCanStartReplication = true)
                .With(x => x.isReplicationAvailable = true)
                .With(x => x.isAlive = true)
                ;
            
            stateMachine.Enter<RabbitIdleState>();

            return rabbitEntity;
        }
    }
}
using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Common.Random;
using Code.Gameplay.Features.Rabbits.Config;
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

        public GameEntity Create(RabbitType type, Vector3 at, int stallIndex)
        {
            RabbitConfig config = _staticDataService.GetRabbitConfig(type);

            switch (type)
            {
                case RabbitType.Simple:
                    return SimpleRabbit(config, at, stallIndex);
                
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, $"Cannot create rabbit with type {type}");
            }
        }

        private GameEntity SimpleRabbit(RabbitConfig rabbitConfig, Vector3 at, int stallIndex)
        {
            GameEntity rabbitEntity = CreateEntity
                .Empty();
            
            IRabbitStateFactory stateFactory = new RabbitStateFactory(_container, rabbitEntity);
            RabbitStateMachine stateMachine = new RabbitStateMachine(stateFactory);

            float intervalBeforeNextReplication = _randomService.Range(rabbitConfig.MinIntervalBetweenReplication,
                rabbitConfig.MaxIntervalBetweenReplication);
            
            rabbitEntity
                .AddId(_identifierService.Next())
                .AddRabbitType(rabbitConfig.Type)
                .AddDefaultReplicationDuration(rabbitConfig.ReplicationDuration)
                .AddCurrentReplicationDuration(rabbitConfig.ReplicationDuration)
                .AddReplicationInterval(intervalBeforeNextReplication)
                .AddMinReplicationInterval(rabbitConfig.MinIntervalBetweenReplication)
                .AddMaxReplicationInterval(rabbitConfig.MaxIntervalBetweenReplication)
                .AddReplicationTimeLeft(rabbitConfig.ReplicationDuration)
                .AddTimeLeftForNextReplication(intervalBeforeNextReplication)
                .AddMinRabbitsSpawnAfterReplication(rabbitConfig.MinRabbitsSpawnAfterReplication)
                .AddMaxRabbitsSpawnAfterReplication(rabbitConfig.MaxRabbitsSpawnAfterReplication)
                .AddMovingInterval(rabbitConfig.IntervalBetweenMoving)
                .AddTimeLeftForMoving(0)
                .AddWorldPosition(at)
                .AddStallParentIndex(stallIndex)
                .AddViewPrefab(rabbitConfig.View)
                .AddParentTransform(_levelDataProvider.RabbitSpawnParent)
                .AddRabbitTypesForReplicationWith(rabbitConfig.RabbitTypesForReplicationWith)
                .AddSpeed(rabbitConfig.Speed)
                .AddSelectionDragMaxTime(rabbitConfig.TimeToRelease)
                .AddSelectionDragTimeLeft(rabbitConfig.TimeToRelease)
                .AddRabbitStateMachine(stateMachine)
                .AddWaitReplicationDuration(rabbitConfig.WaitReplicationDuration)
                .AddWaitReplicationTimeLeft(rabbitConfig.WaitReplicationDuration)
                .With(x => x.isRabbit = true)
                .With(x => x.isSaveRotationInSpawn = true)
                .With(x => x.isTurnedAlongDirection = true)
                .With(x => x.isIdleState = true)
                .With(x => x.isSelectable = true)
                .With(x => x.isCanStartReplication = true)
                ;
            
            stateMachine.Enter<RabbitIdleState>();

            return rabbitEntity;
        }
    }
}
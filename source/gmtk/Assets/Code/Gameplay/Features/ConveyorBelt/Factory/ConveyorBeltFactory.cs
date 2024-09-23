using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Level.Config;
using Code.Gameplay.Levels;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.ConveyorBelt.Factory
{
    public class ConveyorBeltFactory : IConveyorBeltFactory
    {
        private readonly ILevelDataProvider _levelDataProvider;
        private readonly IIdentifierService _identifierService;

        public ConveyorBeltFactory(ILevelDataProvider levelDataProvider, IIdentifierService identifierService)
        {
            _levelDataProvider = levelDataProvider;
            _identifierService = identifierService;
        }
        
        public GameEntity Create(ConveyorBeltData createData)
        {
            return CreateEntity
                .Empty()
                .AddId(_identifierService.Next())
                .AddSpeed(createData.Speed)
                .AddConveyorStartPoint(createData.StartPosition)
                .AddConveyorEndPoint(createData.EndPosition)
                .AddConveyorStartStall(createData.StartStallIndex)
                .AddConveyorEndStall(createData.EndStallIndex)
                .AddElementsOnConveyor(new List<int>(8))
                .AddConveyorMoveDirection((createData.EndPosition - createData.StartPosition).normalized)
                .AddViewPrefab(createData.View)
                .AddWorldPosition((createData.StartPosition + createData.EndPosition) / 2)
                .AddParentTransform(_levelDataProvider.ConveyorBeltSpawnParent)
                .AddTargetBuffer(new List<int>(8))
                .AddCollectTargetsInterval(createData.InteractionInterval)
                .AddCollectTargetsTimeLeft(createData.InteractionInterval)
                .AddRadius(createData.InteractionRadius)
                .AddTargetCollectionLayerMask(createData.TargetCollectionLayerMask)
                .AddTargetCollectionCastPoint(createData.StartPosition)
                .With(x => x.isConveyorBelt = true)
                ;
        }
    }
}
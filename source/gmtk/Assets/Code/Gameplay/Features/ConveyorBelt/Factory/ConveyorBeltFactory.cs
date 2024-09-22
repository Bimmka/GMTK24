using System.Collections.Generic;
using Code.Common.Entity;
using Code.Gameplay.Features.Level.Config;
using Code.Gameplay.Levels;
using UnityEngine;

namespace Code.Gameplay.Features.ConveyorBelt.Factory
{
    public class ConveyorBeltFactory : IConveyorBeltFactory
    {
        private readonly ILevelDataProvider _levelDataProvider;

        public ConveyorBeltFactory(ILevelDataProvider levelDataProvider)
        {
            _levelDataProvider = levelDataProvider;
        }
        
        public GameEntity Create(ConveyorBeltData createData)
        {
            return CreateEntity
                .Empty()
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
                ;
        }
    }
}
using System.Collections.Generic;
using Code.Common.Entity;
using Code.Gameplay.Features.Selection.Config;
using Code.Gameplay.StaticData;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Selection.Systems
{
    public class InitializeSelectionSystem : IInitializeSystem
    {
        private readonly IStaticDataService _staticDataService;

        public InitializeSelectionSystem(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public void Initialize()
        {
            SelectionConfig config = _staticDataService.GetSelectionConfig();
            
            CreateEntity
                .Empty()
                .AddSelectedEntities(new List<int>())
                .AddSelectionLayerMask(config.SelectionMask)
                .AddSelectCenterPosition(Vector3.zero)
                .AddSelectCenterRadius(config.SelectionRadius)
                .AddFollowSelectCenterSpeed(config.FollowSelectionCenterSpeed)
                .AddMoveToAfterDragPositionSpeed(config.MoveToAfterDragPositionSpeed);
        }
    }
}
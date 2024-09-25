using System;
using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Features.ConveyorBelt.Behaviours
{
    public class ApplyConveyorBeltVisualScale : MonoBehaviour
    {
        public EntityBehaviour EntityBehaviour;
        public SpriteRenderer ConveyorBeltSprite;
        public BoxCollider2D ConveyorBeltCollider;
        
        private void Start()
        {
            if (EntityBehaviour.Entity.hasConveyorStartPoint == false || EntityBehaviour.Entity.hasConveyorEndPoint == false)
                return;

            Vector3 startPoint = EntityBehaviour.Entity.ConveyorStartPoint;
            Vector3 endPoint = EntityBehaviour.Entity.ConveyorEndPoint;
            
            Vector2 tempSpriteSize = ConveyorBeltSprite.size;
            Vector2 colliderSize = ConveyorBeltCollider.size;

            if (startPoint.y == endPoint.y)
            {
                float xSize = Mathf.Abs(endPoint.x - startPoint.x);
                tempSpriteSize.x = xSize;
                colliderSize.x = xSize;
               
            }
            else if (startPoint.x == endPoint.x)
            {
                float ySize = Mathf.Abs(endPoint.y - startPoint.y);
                tempSpriteSize.y = ySize;
                colliderSize.y = ySize;
            }
            
            ConveyorBeltSprite.size = tempSpriteSize;
            ConveyorBeltCollider.size = colliderSize;
        }
    }
}
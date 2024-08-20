using System;
using System.Linq;
using Spine.Unity;
using UnityEngine;

namespace Code.Gameplay.Features.Rabbits.Behaviours.Animations
{
    public class SkeletPointPositionHolder : MonoBehaviour
    {
        public SkeletonAnimation SkeletonAnimation; 
        public string Id;

        private int index;

        private void Awake()
        {
            index = SkeletonAnimation.Skeleton.Bones.Items.FirstOrDefault(x => x.Data.Name == Id)?.Data.Index ?? -1;
        }

        private void Update()
        {
            if (index < 0)
                return;
            
            transform.position = SkeletonAnimation.Skeleton.Bones.Items[index].GetWorldPosition(SkeletonAnimation.transform);
        }
    }
}
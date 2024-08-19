using System;
using Code.Gameplay.Features.Rabbits.Config.Rabbits;
using Spine;
using Spine.Unity;
using UnityEngine;
using AnimationState = Spine.AnimationState;

namespace Code.Gameplay.Features.Rabbits.Behaviours.Animations
{
    public class RabbitAnimator : MonoBehaviour
    {
        public SkeletonAnimation SkeletonAnimation;

        [SpineAnimation] public string IdleAnimationName;
        [SpineAnimation] public string MovingAnimationName;
        [SpineAnimation] public string DraggingAnimationName;
        [SpineAnimation] public string MoveToReplicationAnimationName;
        [SpineAnimation] public string DeadAnimationName;

        private AnimationState spineAnimationState;

        public void Initialize(RabbitColorType color)
        {
            Skin skin = SkeletonAnimation.Skeleton.Data.FindSkin(color.ToString().ToLower());
            SkeletonAnimation.Skeleton.SetSkin(skin);
            spineAnimationState = SkeletonAnimation.AnimationState;
        }

        public void PlayIdle()
        {
            spineAnimationState.SetAnimation(0, IdleAnimationName, true);
        }

        public void PlayMoving()
        {
            spineAnimationState.SetAnimation(0, MovingAnimationName, true);
        }

        public void PlayDragging()
        {
            spineAnimationState.SetAnimation(0, DraggingAnimationName, true);
        }

        public void PlayMoveToReplication()
        {
            spineAnimationState.SetAnimation(0, MoveToReplicationAnimationName, true);
        }

        public void PlayDead()
        {
            spineAnimationState.SetAnimation(0, IdleAnimationName, true);
        }
    }
}
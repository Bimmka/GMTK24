using Code.Gameplay.Features.Rabbits.Config.Rabbits;
using Spine;
using Spine.Unity;
using UnityEngine;
using AnimationState = Spine.AnimationState;

namespace Code.Gameplay.Features.Foxes.Behaviours.Animations
{
    public class FoxAnimator : MonoBehaviour
    {
        public SkeletonAnimation SkeletonAnimation;

        [SpineAnimation] public string IdleAnimationName;
        [SpineAnimation] public string EatingAnimationName;
        [SpineAnimation] public string MoveAnimationName;
        [SpineAnimation] public string HuntAnimationName;

        private AnimationState spineAnimationState;

        public void Awake()
        {
            spineAnimationState = SkeletonAnimation.AnimationState;
        }
        
        public void PlayMove()
        {
            spineAnimationState.SetAnimation(0, MoveAnimationName, true);
        }
        
        public void PlayHunt()
        {
            spineAnimationState.SetAnimation(0, HuntAnimationName, true);
        }

        public void StopMove()
        {
            spineAnimationState.SetAnimation(0, IdleAnimationName, true);
        }

        public void PlayIdle()
        {
            spineAnimationState.SetAnimation(0, IdleAnimationName, true);
        }

        public void PlayEating()
        {
            spineAnimationState.SetAnimation(0, EatingAnimationName, true);
        }
    }
}
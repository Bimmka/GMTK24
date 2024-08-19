using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Features.Foxes.Config
{
    [CreateAssetMenu(menuName = "StaticData/Foxes/Create Fox Config", fileName = "FoxConfig")]
    public class FoxConfig : ScriptableObject
    {
        public EntityBehaviour View;
        
        [Header("Speed")]
        public float MaxSpeed = 1f;
        public float MinSpeed = 1f;

        [Header("Hunt Duration")]
        public float MinHuntDuration = 1f;
        public float MaxHuntDuration = 1f;
        
        [Header("Interval Between Hunts")]
        public float MinBeforeNextHuntInterval = 1f;
        public float MaxBeforeNextHuntInterval = 1f;

        [Header("How Many Rabbits Can Eat")]
        public int MinRabbitsToGetEnough = 1;
        public int MaxRabbitsToGetEnough = 1;
        
        [Header("Simple Move")]
        public float MinIntervalBetweenMoving = 1f;
        public float MaxIntervalBetweenMoving = 1f;
        
        [Header("Drag Release")]
        public float MinDragReleaseDuration = 1f;
        public float MaxDragReleaseDuration = 1f;

        public float EatingTime = 0.5f;
    }
}
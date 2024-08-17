using Code.Infrastructure.View;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Gameplay.Features.Rabbits.Config
{
    [CreateAssetMenu(menuName = "StaticData/Rabbit Config/Create Rabbit Config", fileName = "RabbitConfig")]
    public class RabbitConfig : ScriptableObject
    {
        public RabbitType Type;
        public EntityBehaviour View;

        public float IntervalBetweenMoving = 1f;

        public float IntervalBetweenReplication = 1f;
        public float ReplicationDuration = 1f;
        public int MinRabbitsSpawnAfterReplication = 1;
        public int MaxRabbitsSpawnAfterReplication = 1;
        public RabbitType[] RabbitTypesForReplicationWith;

        public float Speed = 1f;
    }
}
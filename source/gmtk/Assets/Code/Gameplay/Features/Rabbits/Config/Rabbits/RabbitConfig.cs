using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Features.Rabbits.Config.Rabbits
{
    [CreateAssetMenu(menuName = "StaticData/Rabbits Config/Create Rabbit Config", fileName = "RabbitConfig")]
    public class RabbitConfig : ScriptableObject
    {
        public RabbitColorType ColorType;
        public EntityBehaviour View;

        [Header("Interval Between Moving")]
        public float MinIntervalBetweenMoving = 1f;
        public float MaxIntervalBetweenMoving = 1f;

        [Header("Interval Between Replicatin")]
        public float MinIntervalBetweenReplication = 1f;
        public float MaxIntervalBetweenReplication = 2f;
        
        [Header("Replication Process Duration")]
        public float MinReplicationDuration = 1f;
        public float MaxReplicationDuration = 1f;
        
        [Header("Time For Next Replication")]
        public float MinWaitReplicationDuration = 5f;
        public float MaxWaitReplicationDuration = 5f;

        [Header("Speed")]
        public float MinSpeed = 1f;
        public float MaxSpeed = 1f;
        
        [Header("Time To Release From Drag")]
        public float MinTimeToReleaseFromDrag = 4f;
        public float MaxTimeToReleaseFromDrag = 4f;
    }
}
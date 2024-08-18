using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Features.Rabbits.Config.Rabbits
{
    [CreateAssetMenu(menuName = "StaticData/Rabbits Config/Create Rabbit Config", fileName = "RabbitConfig")]
    public class RabbitConfig : ScriptableObject
    {
        public RabbitColorType ColorType;
        public EntityBehaviour View;

        public float IntervalBetweenMoving = 1f;

        public float MinIntervalBetweenReplication = 1f;
        public float MaxIntervalBetweenReplication = 2f;
        public float ReplicationDuration = 1f;
        public float WaitReplicationDuration = 5f;

        public float Speed = 1f;
        public float TimeToRelease = 4f;
    }
}
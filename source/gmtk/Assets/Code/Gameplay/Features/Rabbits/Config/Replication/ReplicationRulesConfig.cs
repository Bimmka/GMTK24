using UnityEngine;

namespace Code.Gameplay.Features.Rabbits.Config.Replication
{
    [CreateAssetMenu(menuName = "StaticData/Rabbits Config/Create Replication Rules Config", fileName = "ReplicationRulesConfig")]
    public class ReplicationRulesConfig : ScriptableObject
    {
        public int ReplicateRabbitAmount = 1;
        
        public RabbitColorWeight[] ColorWeights;
        public ColorMixing[] ColorMixings;

        public float RecessiveColorMixingWeight = 950;
    }
}
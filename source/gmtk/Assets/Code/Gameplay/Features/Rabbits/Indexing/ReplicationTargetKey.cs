using Code.Gameplay.Features.Rabbits.Config;

namespace Code.Gameplay.Features.Rabbits.Indexing
{
    public struct ReplicationTargetKey
    {
        public readonly int StallIndex;
        public readonly RabbitType Type;

        public ReplicationTargetKey(int stallIndex, RabbitType type)
        {
            StallIndex = stallIndex;
            Type = type;
        }
    }
}
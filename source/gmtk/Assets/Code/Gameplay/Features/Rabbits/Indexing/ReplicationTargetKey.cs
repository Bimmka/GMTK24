using Code.Gameplay.Features.Rabbits.Config;

namespace Code.Gameplay.Features.Rabbits.Indexing
{
    public struct ReplicationTargetKey
    {
        public readonly int StallIndex;

        public ReplicationTargetKey(int stallIndex)
        {
            StallIndex = stallIndex;
        }
    }
}
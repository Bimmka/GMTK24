using System.Collections.Generic;
using Code.Gameplay.Features.Rabbits.Indexing;
using Entitas;

namespace Code.Common.EntityIndices
{
    public static class ContextIndicesExtensions
    {
        public static HashSet<GameEntity> ReplicationTargets(this GameContext context, int stallIndex)
        {
            return ((EntityIndex<GameEntity, ReplicationTargetKey>) context.GetEntityIndex(GameEntityIndices.ReplicationTarget))
                .GetEntities(new ReplicationTargetKey(stallIndex));
        }
    }
}
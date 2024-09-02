using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Replication.Systems
{
    public class ResetDraggingReplicationTargetSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _targets;
        private readonly IGroup<GameEntity> _replicators;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public ResetDraggingReplicationTargetSystem(GameContext game)
        {
            _targets = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ChosenForReplicationBy,
                    GameMatcher.ChosenForReplication,
                    GameMatcher.Rabbit,
                    GameMatcher.Id,
                    GameMatcher.Dragging,
                    GameMatcher.InvalidReplicationTarget));
        }

        public void Execute()
        {
            foreach (GameEntity target in _targets.GetEntities(_buffer))
            {
                target.isChosenForReplication = false;
                target.isInvalidReplicationTarget = false;
                target.RemoveChosenForReplicationBy();
            }
        }
    }
}
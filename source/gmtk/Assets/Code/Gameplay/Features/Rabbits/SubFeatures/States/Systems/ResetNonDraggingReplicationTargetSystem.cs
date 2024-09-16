using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.States.Systems
{
    public class ResetNonDraggingReplicationTargetSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _targets;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public ResetNonDraggingReplicationTargetSystem(GameContext game)
        {
            _targets = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ChosenForReplicationBy,
                    GameMatcher.ChosenForReplication,
                    GameMatcher.Rabbit,
                    GameMatcher.Id,
                    GameMatcher.InvalidReplicationTarget)
                .NoneOf(GameMatcher.Dragging));
        }

        public void Execute()
        {
            foreach (GameEntity target in _targets.GetEntities(_buffer))
            {
                target.isChosenForReplication = false;
                target.isCanBeChosenForReplication = true;
                target.isWaitingForNextReplicationUp = true;
                target.isCanStartReplication = true;
                target.isReplicationTimeUp = false;
                target.isInvalidReplicationTarget = false;
                
                target.RemoveChosenForReplicationBy();
            }
        }
    }
}
using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Foxes.SubFeatures.Hunt.Systems
{
    public class ValidateHuntTargetSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _foxes;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public ValidateHuntTargetSystem(GameContext game)
        {
            _game = game;
            _foxes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fox,
                    GameMatcher.Alive,
                    GameMatcher.HuntTarget,
                    GameMatcher.ValidHuntTarget,
                    GameMatcher.StallParentIndex));
        }

        public void Execute()
        {
            foreach (GameEntity fox in _foxes.GetEntities(_buffer))
            {
                GameEntity huntTarget = _game.GetEntityWithId(fox.HuntTarget);

                if (huntTarget.isDead || huntTarget.isDragging || huntTarget.StallParentIndex != fox.StallParentIndex || huntTarget.isReplicating)
                {
                    RemoveValidTarget(fox);
                    fox.isWaitingNextHuntTarget = true;
                }
            }
        }

        private void RemoveValidTarget(GameEntity fox)
        {
            fox.isValidHuntTarget = false;
            fox.isInvalidHuntTarget = true;
        }
    }
}
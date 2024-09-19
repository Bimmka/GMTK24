using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Foxes.SubFeatures.Hunt.Systems
{
    public class StartEatingSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _foxes;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public StartEatingSystem(GameContext game)
        {
            _game = game;
            _foxes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fox,
                    GameMatcher.Alive,
                    GameMatcher.HuntTarget,
                    GameMatcher.ValidHuntTarget,
                    GameMatcher.Eating,
                    GameMatcher.EatingStarted,
                    GameMatcher.FoxAnimator));
        }

        public void Execute()
        {
            foreach (GameEntity fox in _foxes.GetEntities(_buffer))
            {
                fox.isMovingToHuntTarget = false;
                fox.isMoving = false;
                fox.isMovementAvailable = false;
                fox.isNearHuntTarget = false;

                fox.FoxAnimator.PlayEating();

                GameEntity target = _game.GetEntityWithId(fox.HuntTarget);
                target.isEaten = true;

                fox.RemoveHuntTarget();
                fox.isValidHuntTarget = false;

                if (fox.hasAttachedSound)
                {
                    fox.AttachedSound.Reset();
                    fox.RemoveAttachedSound();
                }
            }
        }
    }
}
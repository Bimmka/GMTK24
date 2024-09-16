using Code.Gameplay.VFX.Config;
using Code.Gameplay.VFX.Service;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Death.Systems
{
    public class PrepareForDeathSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;

        public PrepareForDeathSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.Dead,
                    GameMatcher.DeadByInfection,
                    GameMatcher.RabbitAnimator));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                rabbit.isMovingUp = false;
                rabbit.isWaitingForMoving = false;
                rabbit.isMoving = false;
                rabbit.isMovementAvailable = false;
                rabbit.isReplicationAvailable = false;
                rabbit.isReplicationBlocked = true;
                rabbit.isSelectable = false;
                
                rabbit.RabbitAnimator.PlayDead();

                rabbit.isDestructed = true;
            }
        }
    }
}
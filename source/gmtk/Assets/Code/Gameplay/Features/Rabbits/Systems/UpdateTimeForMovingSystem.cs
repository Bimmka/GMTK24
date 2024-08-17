using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.Systems
{
    public class UpdateTimeForMovingSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _rabbits;

        public UpdateTimeForMovingSystem(GameContext game, ITimeService time)
        {
            _time = time;
            
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.TimeLeftForMoving,
                    GameMatcher.WaitingForMoving,
                    GameMatcher.MovementAvailable));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                rabbit.ReplaceTimeLeftForMoving(rabbit.TimeLeftForMoving - _time.DeltaTime);

                if (rabbit.TimeLeftForMoving <= 0)
                    rabbit.isMovingUp = true;
            }
        }
    }
}
using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.Foxes.SubFeatures.SimpleMove.Systems
{
    public class UpdateNextMovingTimeLeftSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _foxes;

        public UpdateNextMovingTimeLeftSystem(GameContext game, ITimeService time)
        {
            _time = time;
            
            _foxes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fox,
                    GameMatcher.WaitingForMoving,
                    GameMatcher.TimeLeftForMoving,
                    GameMatcher.Alive)
                .NoneOf(GameMatcher.Hungry));
        }

        public void Execute()
        {
            foreach (GameEntity fox in _foxes)
            {
                fox.ReplaceTimeLeftForMoving(fox.TimeLeftForMoving - _time.DeltaTime);
            }
        }
    }
}
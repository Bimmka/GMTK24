using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.Foxes.Systems
{
    public class UpdateEatingTimeLeftSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _foxes;

        public UpdateEatingTimeLeftSystem(GameContext game, ITimeService time)
        {
            _time = time;
            
            _foxes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fox,
                    GameMatcher.Eating,
                    GameMatcher.EatingTimeLeft));
        }

        public void Execute()
        {
            foreach (GameEntity fox in _foxes)
            {
                fox.ReplaceEatingTimeLeft(fox.EatingTimeLeft - _time.DeltaTime);
            }
        }
    }
}
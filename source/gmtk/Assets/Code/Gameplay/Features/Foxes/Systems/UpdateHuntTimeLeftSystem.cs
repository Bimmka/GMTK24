using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.Foxes.Systems
{
    public class UpdateHuntTimeLeftSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _foxes;

        public UpdateHuntTimeLeftSystem(GameContext game, ITimeService time)
        {
            _time = time;
            
            _foxes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fox,
                    GameMatcher.Hungry,
                    GameMatcher.Alive,
                    GameMatcher.HuntTimeLeft));
        }

        public void Execute()
        {
            foreach (GameEntity fox in _foxes)
            {
                fox.ReplaceHuntTimeLeft(fox.HuntTimeLeft - _time.DeltaTime);
            }
        }
    }
}
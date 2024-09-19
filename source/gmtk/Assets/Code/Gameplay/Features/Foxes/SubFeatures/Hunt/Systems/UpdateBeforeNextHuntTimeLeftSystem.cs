using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.Foxes.SubFeatures.Hunt.Systems
{
    public class UpdateBeforeNextHuntTimeLeftSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _foxes;

        public UpdateBeforeNextHuntTimeLeftSystem(GameContext game, ITimeService time)
        {
            _time = time;
            
            _foxes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fox,
                    GameMatcher.BeforeNextHuntTimeLeft,
                    GameMatcher.Alive,
                    GameMatcher.WaitingHunt));
        }

        public void Execute()
        {
            foreach (GameEntity fox in _foxes)
            {
                fox.ReplaceBeforeNextHuntTimeLeft(fox.BeforeNextHuntTimeLeft - _time.DeltaTime);
            }
        }
    }
}
using Entitas;

namespace Code.Gameplay.Features.LevelFinish.Systems
{
    public class MarkSignalsDestructedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _signals;

        public MarkSignalsDestructedSystem(GameContext game)
        {
            _signals = game.GetGroup(GameMatcher
                .AnyOf(
                    GameMatcher.Lose,
                    GameMatcher.Win));
        }

        public void Execute()
        {
            foreach (GameEntity signal in _signals)
            {
                signal.isDestructed = true;
            }
        }
    }
}
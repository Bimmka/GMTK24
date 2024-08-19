using Entitas;

namespace Code.Gameplay.Features.Foxes.Systems
{
    public class MarkHuntFinishedByNoValidTargetsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _foxes;

        public MarkHuntFinishedByNoValidTargetsSystem(GameContext game)
        {
            _foxes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fox,
                    GameMatcher.Hungry,
                    GameMatcher.Alive,
                    GameMatcher.NoValidTargets));
        }

        public void Execute()
        {
            foreach (GameEntity fox in _foxes)
            {
                fox.isHuntFinished = true;
            }
        }
    }
}
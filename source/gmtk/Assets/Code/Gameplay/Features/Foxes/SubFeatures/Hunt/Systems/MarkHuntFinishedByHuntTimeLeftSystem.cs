using Entitas;

namespace Code.Gameplay.Features.Foxes.SubFeatures.Hunt.Systems
{
    public class MarkHuntFinishedByHuntTimeLeftSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _foxes;

        public MarkHuntFinishedByHuntTimeLeftSystem(GameContext game)
        {
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
                if (fox.HuntTimeLeft <= 0)
                    fox.isHuntFinished = true;
            }
        }
    }
}
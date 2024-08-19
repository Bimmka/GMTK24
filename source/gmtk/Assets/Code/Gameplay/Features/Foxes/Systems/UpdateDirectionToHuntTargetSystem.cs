using Entitas;

namespace Code.Gameplay.Features.Foxes.Systems
{
    public class UpdateDirectionToHuntTargetSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _foxes;

        public UpdateDirectionToHuntTargetSystem(GameContext game)
        {
            _game = game;
            _foxes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fox,
                    GameMatcher.Alive,
                    GameMatcher.HuntTarget,
                    GameMatcher.WorldPosition,
                    GameMatcher.ValidHuntTarget,
                    GameMatcher.MovementAvailable,
                    GameMatcher.MovingToHuntTarget));
        }

        public void Execute()
        {
            foreach (GameEntity fox in _foxes)
            {
                GameEntity huntTarget = _game.GetEntityWithId(fox.HuntTarget);
                fox.ReplaceMoveDirection((huntTarget.WorldPosition - fox.WorldPosition).normalized);
            }
        }
    }
}
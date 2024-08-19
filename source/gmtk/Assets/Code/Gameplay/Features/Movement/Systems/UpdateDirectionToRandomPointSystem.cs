using Entitas;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class UpdateDirectionToRandomPointSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movers;

        public UpdateDirectionToRandomPointSystem(GameContext game)
        {
            _movers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.MovementAvailable, 
                    GameMatcher.TargetPoint));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _movers)
            {
                mover.ReplaceMoveDirection((mover.TargetPoint - mover.WorldPosition).normalized);
            }
        }
    }
}
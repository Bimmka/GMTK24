using Entitas;

namespace Code.Gameplay.Features.Holes.Systems
{
    public class RemoveMarkSpawnUpSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _spawners;

        public RemoveMarkSpawnUpSystem(GameContext game)
        {
            _spawners = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hole));
        }

        public void Execute()
        {
            foreach (GameEntity spawner in _spawners)
            {
                spawner.isSpawnUp = false;
            }
        }
    }
}
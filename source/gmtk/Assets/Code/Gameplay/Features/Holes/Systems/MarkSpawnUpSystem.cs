using Entitas;

namespace Code.Gameplay.Features.Holes.Systems
{
    public class MarkSpawnUpSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _spawners;

        public MarkSpawnUpSystem(GameContext game)
        {
            _spawners = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.SpawnTimeLeft));
        }

        public void Execute()
        {
            foreach (GameEntity spawner in _spawners)
            {
                if (spawner.SpawnTimeLeft <= 0)
                    spawner.isSpawnUp = true;
            }
        }
    }
}
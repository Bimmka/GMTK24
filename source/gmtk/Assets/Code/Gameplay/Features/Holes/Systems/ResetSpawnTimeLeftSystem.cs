using Entitas;

namespace Code.Gameplay.Features.Holes.Systems
{
    public class ResetSpawnTimeLeftSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _spawners;

        public ResetSpawnTimeLeftSystem(GameContext game)
        {
            _spawners = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.SpawnTimeLeft,
                    GameMatcher.SpawnInterval,
                    GameMatcher.SpawnUp));
        }

        public void Execute()
        {
            foreach (GameEntity spawner in _spawners)
            {
                spawner.ReplaceSpawnTimeLeft(spawner.SpawnInterval);
            }
        }
    }
}
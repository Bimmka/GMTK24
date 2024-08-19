using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.Holes.Systems
{
    public class UpdateSpawnTimeLeftSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _spawners;

        public UpdateSpawnTimeLeftSystem(GameContext game, ITimeService time)
        {
            _time = time;
            _spawners = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.SpawnTimeLeft));
        }

        public void Execute()
        {
            foreach (GameEntity spawner in _spawners)
            {
                spawner.ReplaceSpawnTimeLeft(spawner.SpawnTimeLeft - _time.DeltaTime);
            }
        }
    }
}
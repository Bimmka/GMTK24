using Code.Common.Extensions;
using Code.Gameplay.Common.Random;
using Code.Gameplay.Features.Rabbits.Factory;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.Systems
{
    public class SpawnRabbitsAfterReplicationFinishedSystem : IExecuteSystem
    {
        private readonly IRandomService _randomService;
        private readonly IRabbitFactory _rabbitFactory;
        private readonly IGroup<GameEntity> _rabbits;

        public SpawnRabbitsAfterReplicationFinishedSystem(GameContext game, IRandomService randomService, IRabbitFactory rabbitFactory)
        {
            _randomService = randomService;
            _rabbitFactory = rabbitFactory;

            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.ReplicationFinished,
                    GameMatcher.MinRabbitsSpawnAfterReplication,
                    GameMatcher.MaxRabbitsSpawnAfterReplication,
                    GameMatcher.WorldPosition,
                    GameMatcher.RabbitType,
                    GameMatcher.ReplicationPhase));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                int randomChildrenAmount = _randomService.Range(rabbit.MinRabbitsSpawnAfterReplication, rabbit.MaxRabbitsSpawnAfterReplication);

                for (int i = 0; i < randomChildrenAmount; i++)
                {
                    _rabbitFactory
                        .Create(rabbit.RabbitType, rabbit.WorldPosition, rabbit.StallParentIndex)
                        .With(x => x.isMovementAvailable = true)
                        .With(x => x.isWaitingForMoving = true)
                        .With(x => x.isCanBeChosenForReplication = true)
                        .With(x => x.isWaitingForNextReplicationUp = true)
                        ;
                }
            }
        }
    }
}
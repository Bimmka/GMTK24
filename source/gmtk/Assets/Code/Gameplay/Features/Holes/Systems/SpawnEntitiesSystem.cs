using System;
using Code.Gameplay.Common.Random;
using Code.Gameplay.Features.Foxes.Factory;
using Code.Gameplay.Features.Holes.Config;
using Code.Gameplay.Features.Rabbits.Factory;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Holes.Systems
{
    public class SpawnEntitiesSystem : IExecuteSystem
    {
        private readonly IRabbitFactory _rabbitFactory;
        private readonly IFoxFactory _foxFactory;
        private readonly IRandomService _randomService;
        private readonly IGroup<GameEntity> _spawners;

        public SpawnEntitiesSystem(
            GameContext game,
            IRabbitFactory rabbitFactory,
            IFoxFactory foxFactory,
            IRandomService randomService)
        {
            _rabbitFactory = rabbitFactory;
            _foxFactory = foxFactory;
            _randomService = randomService;

            _spawners = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Hole,
                    GameMatcher.SpawnUp,
                    GameMatcher.HoleEntitySpawnData,
                    GameMatcher.WorldPosition,
                    GameMatcher.StallParentIndex));
        }

        public void Execute()
        {
            foreach (GameEntity spawner in _spawners)
            {
                foreach (HoleEntitySpawnData spawnData in spawner.HoleEntitySpawnData)
                {
                    float chance = _randomService.Range(0, 1f);
                    
                    if (chance > spawnData.Chance)
                        continue;

                    Vector3 shift = _randomService.InsideUnitCircle();
                    switch (spawnData.SpawnType)
                    {
                        case SpawnEntityType.Rabbit:
                            _rabbitFactory.Create(spawnData.RabbitColorTypes[_randomService.Range(0, spawnData.RabbitColorTypes.Length)], spawner.WorldPosition + shift, spawner.StallParentIndex);
                            break;
                        case SpawnEntityType.Fox:
                            _foxFactory.Create(spawner.WorldPosition + shift, spawner.StallParentIndex);
                            break;
                    }
                }
            }
        }
    }
}
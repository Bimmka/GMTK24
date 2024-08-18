using System.Collections.Generic;
using System.Linq;
using Code.Common.Extensions;
using Code.Gameplay.Common.Random;
using Code.Gameplay.Features.Rabbits.Config.Rabbits;
using Code.Gameplay.Features.Rabbits.Config.Replication;
using Code.Gameplay.Features.Rabbits.Factory;
using Code.Gameplay.Features.Selection.Config;
using Code.Gameplay.StaticData;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Replication.Systems
{
    public class SpawnRabbitsAfterReplicationFinishedSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IRandomService _randomService;
        private readonly IRabbitFactory _rabbitFactory;
        private readonly IStaticDataService _staticDataService;
        private readonly IGroup<GameEntity> _rabbits;

        public SpawnRabbitsAfterReplicationFinishedSystem(
            GameContext game,
            IRandomService randomService,
            IRabbitFactory rabbitFactory,
            IStaticDataService staticDataService)
        {
            _game = game;
            _randomService = randomService;
            _rabbitFactory = rabbitFactory;
            _staticDataService = staticDataService;

            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.ReplicationFinished,
                    GameMatcher.WorldPosition,
                    GameMatcher.RabbitColorType,
                    GameMatcher.ReplicationState,
                    GameMatcher.ReplicationTarget));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                GameEntity target = _game.GetEntityWithId(rabbit.ReplicationTarget);
                ReplicationRulesConfig config = _staticDataService.GetReplicationRulesConfig();
                
                for (int i = 0; i < config.ReplicateRabbitAmount; i++)
                {
                    RabbitColorType rabbitColorType = GetRabbitChildColor(rabbit, target, config);
                    
                    _rabbitFactory
                        .Create(rabbitColorType, rabbit.WorldPosition, rabbit.StallParentIndex)
                        .With(x => x.isMovementAvailable = true)
                        .With(x => x.isWaitingForMoving = true)
                        .With(x => x.isCanBeChosenForReplication = true)
                        .With(x => x.isWaitingForNextReplicationUp = true)
                        ;
                }
            }
        }

        private RabbitColorType GetRabbitChildColor(GameEntity replicator, GameEntity target, ReplicationRulesConfig config)
        {
            RabbitColorType firstColorType = replicator.RabbitColorType;
            RabbitColorType secondColorType = target.RabbitColorType;

            float firstColorWeight = config.ColorWeights.FirstOrDefault(x => x.ColorType == firstColorType).Weight;
            float secondColorWeight = config.ColorWeights.FirstOrDefault(x => x.ColorType == secondColorType).Weight;

            RabbitColorType recessiveColorType = config.ColorMixings
                .FirstOrDefault(x => (x.FirstColorType == firstColorType && x.SecondColorType == secondColorType) || (x.FirstColorType == secondColorType && x.SecondColorType == firstColorType))
                .ResultColorType;

            List<RabbitColorWeight> colorWeights = new List<RabbitColorWeight>()
            {
                new RabbitColorWeight() {ColorType = firstColorType, Weight = firstColorWeight},
                new RabbitColorWeight() {ColorType = secondColorType, Weight = secondColorWeight}
            };

            if (recessiveColorType != RabbitColorType.None)
            {
                colorWeights.Add(new RabbitColorWeight(){ColorType = recessiveColorType, Weight = config.RecessiveColorMixingWeight});
                
                int randomIndex = GetRandomWeightedIndex(colorWeights);
                
                return colorWeights[randomIndex].ColorType;
            }
            else
            {
                int randomIndex = GetRandomWeightedIndex(colorWeights);
                
                return colorWeights[randomIndex].ColorType;
            }
        }
        
        private int GetRandomWeightedIndex(List<RabbitColorWeight> weights)
        {
            float weightSum = 0;
            for (int i = 0; i < weights.Count; ++i)
            {
                weightSum += weights[i].Weight;
            }
            
            int index = 0;
            int lastIndex = weights.Count - 1;
            while (index < lastIndex)
            {
                if (_randomService.Range(0, weightSum) < weights[index].Weight)
                {
                    return index;
                }
                
                weightSum -= weights[index].Weight;
                index++;
            }
            
            return index;
        }
    }
}
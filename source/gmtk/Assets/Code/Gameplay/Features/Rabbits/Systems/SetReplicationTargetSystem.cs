using System.Collections.Generic;
using System.Linq;
using Code.Common.EntityIndices;
using Code.Gameplay.Common.Random;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.Systems
{
    public class SetReplicationTargetSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IRandomService _randomService;
        private readonly IGroup<GameEntity> _targetRabbits;
        private readonly IGroup<GameEntity> _replicationUpRabbits;
        private readonly List<GameEntity> _replicationUpBuffer = new List<GameEntity>(32);

        public SetReplicationTargetSystem(GameContext game, IRandomService randomService)
        {
            _game = game;
            _randomService = randomService;
            _replicationUpRabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.ReplicationUp,
                    GameMatcher.StallParentIndex,
                    GameMatcher.Id,
                    GameMatcher.RabbitTypesForReplicationWith));
        }

        public void Execute()
        {
            foreach (GameEntity replicationUpRabbit in _replicationUpRabbits.GetEntities(_replicationUpBuffer))
            {
                if (replicationUpRabbit.isCanBeChosenForReplication == false)
                    continue;
                
                GameEntity chosenTarget = GetReplicationTarget(replicationUpRabbit);
                
                if (chosenTarget != null)
                {
                    chosenTarget.isChosenForReplication = true;
                    chosenTarget.RemoveWaitReplicationComponent();
                    chosenTarget.ReplaceChosenForReplicationBy(replicationUpRabbit.Id);

                    replicationUpRabbit.ReplaceReplicationTarget(chosenTarget.Id);
                    replicationUpRabbit.RemoveWaitReplicationComponent();
                }
            }
        }

        private GameEntity GetReplicationTarget(GameEntity replicationUpRabbit)
        {
            GameEntity[] targets = _game
                .ReplicationTargets(replicationUpRabbit.StallParentIndex, replicationUpRabbit.RabbitTypesForReplicationWith[0])
                .Where(x => x.Id != replicationUpRabbit.Id)
                .ToArray();
            

            if (targets.Length > 0)
                return targets[_randomService.Range(0, targets.Length)];
            return null;
        }
    }
}
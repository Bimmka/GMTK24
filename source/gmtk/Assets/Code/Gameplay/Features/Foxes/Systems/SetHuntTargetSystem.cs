using System.Collections.Generic;
using System.Linq;
using Code.Common.EntityIndices;
using Code.Gameplay.Common.Random;
using Entitas;

namespace Code.Gameplay.Features.Foxes.Systems
{
    public class SetHuntTargetSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IRandomService _randomService;
        private readonly IGroup<GameEntity> _foxes;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

        public SetHuntTargetSystem(GameContext game, IRandomService randomService)
        {
            _game = game;
            _randomService = randomService;

            _foxes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fox,
                    GameMatcher.Hungry,
                    GameMatcher.Alive,
                    GameMatcher.StallParentIndex,
                    GameMatcher.FoxAnimator,
                    GameMatcher.WorldPosition,
                    GameMatcher.WaitingNextHuntTarget));
        }

        public void Execute()
        {
            foreach (GameEntity fox in _foxes.GetEntities(_buffer))
            {
                List<GameEntity> rabbits = _game.RabbitsForHunt(fox.StallParentIndex).ToList();

                if (rabbits.Count == 0)
                {
                    fox.isNoValidTargets = true;
                    continue;
                }

                GameEntity randomRabbit = rabbits[_randomService.Range(0, rabbits.Count)];

                fox.ReplaceHuntTarget(randomRabbit.Id);
                fox.isValidHuntTarget = true;
                fox.isInvalidHuntTarget = false;
                fox.isWaitingNextHuntTarget = false;
                fox.isNoValidTargets = false;
            }
        }
    }
}
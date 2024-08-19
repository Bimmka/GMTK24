using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Rabies.Systems
{
    public class MarkReplicationBlockedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;

        public MarkReplicationBlockedSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.CarrierOfRabiesInfection,
                    GameMatcher.Rabbit));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                rabbit.isReplicationBlocked = true;
            }
        }
    }
}
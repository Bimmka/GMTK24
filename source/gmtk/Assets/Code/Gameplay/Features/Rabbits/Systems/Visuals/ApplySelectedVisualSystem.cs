using Entitas;

namespace Code.Gameplay.Features.Rabbits.Systems.Visuals
{
    public class ApplySelectedVisualSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;

        public ApplySelectedVisualSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.RabbitVisualChanger));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                rabbit.RabbitVisualChanger.ApplySelectionStatus(rabbit.isSelected);
            }
        }
    }
}
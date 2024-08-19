using Entitas;

namespace Code.Gameplay.Features.Rabbits.Systems.Visuals
{
    public class UnapplySelectedVisualSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;

        public UnapplySelectedVisualSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.DragFinished,
                    GameMatcher.RabbitVisualChanger,
                    GameMatcher.Alive));
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
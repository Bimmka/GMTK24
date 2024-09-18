using Entitas;

namespace Code.Gameplay.Features.Selection.Systems
{
    public class SelectByClickSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _selections;
        private readonly IGroup<InputEntity> _rabbitClicks;

        public SelectByClickSystem(InputContext input, GameContext game)
        {
            _game = game;

            _rabbitClicks = input.GetGroup(InputMatcher
                .AllOf(
                    InputMatcher.Click,
                    InputMatcher.ClickedEntityId,
                    InputMatcher.RabbitClicked));

            _selections = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.EntitiesForSelectionQueue)
                .NoneOf(GameMatcher.Dragging));
        }

        public void Execute()
        {
            foreach (InputEntity click in _rabbitClicks)
            {
                foreach (GameEntity selection in _selections)
                {
                    var clickedRabbit = _game.GetEntityWithId(click.ClickedEntityId);
                    
                    if (clickedRabbit == null)
                        continue;
                    
                    selection.EntitiesForSelectionQueue.Enqueue(click.ClickedEntityId);
                    clickedRabbit.isSelected = true;
                }
            }
        }
    }
}
using Entitas;

namespace Code.Gameplay.Features.Foxes.Systems
{
    public class UpdateHuntTimeAfterClickSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _foxes;
        private readonly IGroup<InputEntity> _clicks;

        public UpdateHuntTimeAfterClickSystem(GameContext game, InputContext input)
        {
            _foxes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fox,
                    GameMatcher.Alive,
                    GameMatcher.Hungry,
                    GameMatcher.HuntTimeLeft,
                    GameMatcher.Id));

            _clicks = input.GetGroup(InputMatcher.AllOf(
                InputMatcher.Click,
                InputMatcher.ClickedEntityId,
                InputMatcher.FoxClicked));
        }

        public void Execute()
        {
            foreach (InputEntity click in _clicks)
            {
                foreach (GameEntity fox in _foxes)
                {
                    if (fox.Id != click.ClickedEntityId)
                        continue;
                    
                    fox.ReplaceHuntTimeLeft(fox.HuntTimeLeft + 0.1f);   
                }
            }
        }
    }
}
using Entitas;

namespace Code.Gameplay.Features.Selection.Systems
{
    public class MarkWaitingMouseDragFinishSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _selections;
        private readonly IGroup<InputEntity> _inputs;

        public MarkWaitingMouseDragFinishSystem(GameContext game, InputContext input)
        {
            _selections = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Selection));

            _inputs = input.GetGroup(InputMatcher
                .AllOf(
                    InputMatcher.Input,
                    InputMatcher.Draging));
        }

        public void Execute()
        {
            foreach (InputEntity input in _inputs)
            {
                foreach (GameEntity selection in _selections)
                {
                    selection.isWaitingMouseDragFinish = true;
                }
            }
        }
    }
}
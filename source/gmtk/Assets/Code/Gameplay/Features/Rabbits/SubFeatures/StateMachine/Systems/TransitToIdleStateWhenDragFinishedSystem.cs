using Code.Gameplay.Features.Rabbits.StateMachine.States;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.StateMachine.Systems
{
    public class TransitToIdleStateWhenDragFinishedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _stateMachines;

        public TransitToIdleStateWhenDragFinishedSystem(GameContext game)
        {
            _stateMachines = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.DragFinished,
                    GameMatcher.Rabbit,
                    GameMatcher.DraggingState,
                    GameMatcher.RabbitStateMachine,
                    GameMatcher.Alive));
        }

        public void Execute()
        {
            foreach (GameEntity stateMachine in _stateMachines)
            {
                stateMachine.ReplaceRabbitNextSimpleState(typeof(RabbitIdleState));
            }
        }
    }
}
using Code.Gameplay.Features.Rabbits.StateMachine.States;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.StateMachine.Systems
{
    public class TransitToIdleStateWhenMovingFinishedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _stateMachines;

        public TransitToIdleStateWhenMovingFinishedSystem(GameContext game)
        {
            _stateMachines = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.RabbitStateMachine,
                    GameMatcher.MovingFinished,
                    GameMatcher.StupidMoveState,
                    GameMatcher.Rabbit,
                    GameMatcher.Alive));
        }

        public void Execute()
        {
            foreach (GameEntity stateMachine in _stateMachines)
            {
                stateMachine.ReplaceRabbitNextSimpleState(typeof(RabbitIdleState));
                stateMachine.isCleanupMovingFinished = true;
            }
        }
    }
}
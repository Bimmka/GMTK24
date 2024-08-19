using Code.Gameplay.Features.Rabbits.StateMachine.States;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.StateMachine.Systems
{
    public class TransitToDeadStateSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _stateMachines;

        public TransitToDeadStateSystem(GameContext game)
        {
            _stateMachines = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.RabbitStateMachine,
                    GameMatcher.Dead,
                    GameMatcher.Rabbit)
                .NoneOf(GameMatcher.DeadState));
        }

        public void Execute()
        {
            foreach (GameEntity stateMachine in _stateMachines)
            {
                stateMachine.ReplaceRabbitNextSimpleState(typeof(RabbitDeadState));
            }
        }
    }
}
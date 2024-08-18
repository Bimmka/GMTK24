using Code.Gameplay.Features.Rabbits.StateMachine.States;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.StateMachine.Systems
{
    public class TransitToIdleStateWhenReplicationInvalidSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _stateMachines;

        public TransitToIdleStateWhenReplicationInvalidSystem(GameContext game)
        {
            _stateMachines = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ReplicationState,
                    GameMatcher.RabbitStateMachine)
                .AnyOf(
                    GameMatcher.InvalidReplicationTarget,
                    GameMatcher.ResetReplicationProcess));
        }

        public void Execute()
        {
            foreach (GameEntity stateMachine in _stateMachines)
            {
                stateMachine.ReplaceRabbitNextSimpleState(typeof(RabbitIdleState));
                stateMachine.isCleanupResetReplicationMarkers = true;
            }
        }
    }
}
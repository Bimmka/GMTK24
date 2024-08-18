using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.StateMachine.Systems
{
   public class UpdateStateMachineStateSystem : IExecuteSystem
   {
      private readonly IGroup<GameEntity> _stateMachines;

      public UpdateStateMachineStateSystem(GameContext game)
      {
         _stateMachines = game.GetGroup(GameMatcher
            .AllOf(GameMatcher.RabbitStateMachine));
      }

      public void Execute()
      {
         foreach (GameEntity stateMachine in _stateMachines)
         {
            stateMachine.RabbitStateMachine.Tick();
         }
      }
   }
}
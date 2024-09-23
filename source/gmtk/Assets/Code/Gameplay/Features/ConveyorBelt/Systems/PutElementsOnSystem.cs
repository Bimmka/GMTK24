using Entitas;

namespace Code.Gameplay.Features.ConveyorBelt.Systems
{
    public class PutElementsOnSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _conveyorBelts;

        public PutElementsOnSystem(GameContext game)
        {
            _game = game;
            _conveyorBelts = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ElementsOnConveyor,
                    GameMatcher.TargetBuffer,
                    GameMatcher.Id));
        }

        public void Execute()
        {
            foreach (GameEntity conveyorBelt in _conveyorBelts)
            {
                foreach (int targetId in conveyorBelt.TargetBuffer)
                {
                    GameEntity target = _game.GetEntityWithId(targetId);

                    if (target == null || target.isDead || target.hasWorldPosition == false || target.isOnConveyorBelt || target.isDragging)
                        continue;

                    conveyorBelt.ElementsOnConveyor.Add(targetId);
                    target.isOnConveyorBelt = true;
                    target.isConveyoringStarted = true;
                    target.ReplaceParentConveyorBeltId(conveyorBelt.Id);
                }
            }
        }
    }
}
using Code.Gameplay.Features.Movement.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Movement
{
    public sealed class MovementFeature : Feature
    {
        public MovementFeature(ISystemFactory systems)
        {
            Add(systems.Create<DirectionalDeltaMoveSystem>());
            Add(systems.Create<MarkTargetPointReachedSystem>());
            Add(systems.Create<TurnAlongDirectionSystem>());
            Add(systems.Create<UpdateTransformPositionSystem>());
        }
    }
}
using Code.Gameplay.Features.Rabbits.SubFeatures.Conveyor;
using Code.Gameplay.Features.Rabbits.SubFeatures.Death;
using Code.Gameplay.Features.Rabbits.SubFeatures.Dragging;
using Code.Gameplay.Features.Rabbits.SubFeatures.Replication;
using Code.Gameplay.Features.Rabbits.SubFeatures.SimpleMove;
using Code.Gameplay.Features.Rabbits.SubFeatures.States;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Rabbits
{
    public sealed class RabbitFeature : Feature
    {
        public RabbitFeature(ISystemFactory systems)
        {
            Add(systems.Create<RabbitDeathFeature>());
            Add(systems.Create<SimpleMovingFeature>());
            Add(systems.Create<ReplicationFeature>());
            Add(systems.Create<DraggingFeature>());
            Add(systems.Create<RabbitConveyorFeature>());
            Add(systems.Create<StatesFeature>());
        }
    }
}
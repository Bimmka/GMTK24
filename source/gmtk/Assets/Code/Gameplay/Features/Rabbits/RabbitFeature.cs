using Code.Gameplay.Features.Rabbits.SubFeatures.Death;
using Code.Gameplay.Features.Rabbits.SubFeatures.Dragging;
using Code.Gameplay.Features.Rabbits.SubFeatures.Replication;
using Code.Gameplay.Features.Rabbits.SubFeatures.States;
using Code.Gameplay.Features.Rabbits.SubFeatures.StupidMove;
using Code.Gameplay.Features.Rabbits.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Rabbits
{
    public sealed class RabbitFeature : Feature
    {
        public RabbitFeature(ISystemFactory systems)
        {
            Add(systems.Create<UpdateMovingMarkSystem>());
            
            Add(systems.Create<RabbitDeathFeature>());
            Add(systems.Create<StupidMovingFeature>());
            Add(systems.Create<ReplicationFeature>());
            Add(systems.Create<DraggingFeature>());
            Add(systems.Create<StatesFeature>());

            //Add(systems.Create<RabbitStateMachineFeature>());
        }
    }
}
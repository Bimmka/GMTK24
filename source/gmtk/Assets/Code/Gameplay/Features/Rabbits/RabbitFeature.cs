using Code.Gameplay.Features.Rabbits.SubFeatures.Dead;
using Code.Gameplay.Features.Rabbits.SubFeatures.Dragging;
using Code.Gameplay.Features.Rabbits.SubFeatures.Idle;
using Code.Gameplay.Features.Rabbits.SubFeatures.Rabies;
using Code.Gameplay.Features.Rabbits.SubFeatures.Replication;
using Code.Gameplay.Features.Rabbits.SubFeatures.StateMachine;
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

            Add(systems.Create<IdleFeature>());
            Add(systems.Create<RabiesFeature>());
            Add(systems.Create<StupidMovingFeature>());
            Add(systems.Create<ReplicationFeature>());
            Add(systems.Create<DraggingFeature>());
            Add(systems.Create<DeadFeature>());
            
            Add(systems.Create<RabbitStateMachineFeature>());
        }
    }
}
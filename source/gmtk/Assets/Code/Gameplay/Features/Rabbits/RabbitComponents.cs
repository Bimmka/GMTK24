using Code.Gameplay.Features.Rabbits.Behaviours.Animations;
using Code.Gameplay.Features.Rabbits.Config;
using Entitas;

namespace Code.Gameplay.Features.Rabbits
{
    [Game] public class Rabbit : IComponent {}
    [Game] public class RabbitTypeComponent : IComponent { public RabbitType Value; }
    
    [Game] public class MovingInterval : IComponent { public float Value; }
    [Game] public class TimeLeftForMoving : IComponent { public float Value; }
    
    [Game] public class ReplicationInterval : IComponent { public float Value; }
    [Game] public class TimeLeftForReplication : IComponent { public float Value; }
    [Game] public class ReplicationDuration : IComponent { public float Value; }
    [Game] public class ReplicationTimeLeft : IComponent { public float Value; }
    [Game] public class ReplicationUp : IComponent {}
    [Game] public class ReplicationFinished : IComponent {}
    [Game] public class Replicating : IComponent {}
    [Game] public class ReplicationTarget : IComponent { public int Value; }
    [Game] public class ChosenForReplication : IComponent {  }
    
    [Game] public class MinRabbitsSpawnAfterReplication : IComponent { public int Value; }
    [Game] public class MaxRabbitsSpawnAfterReplication : IComponent { public int Value; }
    
    [Game] public class RabbitTypesForReplicationWith : IComponent { public RabbitType[] Value; }
    
    [Game] public class StallParentIndex : IComponent { public int Value; }
    
    [Game] public class RabbitAnimatorComponent : IComponent { public RabbitAnimator Value; }
}
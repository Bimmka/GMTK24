using System;
using Code.Gameplay.Features.Rabbits.Behaviours.Animations;
using Code.Gameplay.Features.Rabbits.Behaviours.Visuals;
using Code.Gameplay.Features.Rabbits.Config.Rabbits;
using Code.Gameplay.Features.Rabbits.StateMachine.Base;
using Entitas;

namespace Code.Gameplay.Features.Rabbits
{
    [Game] public class Rabbit : IComponent {}
    [Game] public class RabbitColorTypeComponent : IComponent { public RabbitColorType Value; }
    [Game] public class ActivityFree : IComponent {}
    
    [Game] public class MovingInterval : IComponent { public float Value; }
    [Game] public class TimeLeftForMoving : IComponent { public float Value; }
    [Game] public class MovingUp : IComponent { }
    [Game] public class WaitingForMoving : IComponent { }
    [Game] public class MovingFinished : IComponent { }
    [Game] public class CleanupMovingFinished : IComponent { }
    [Game] public class CleanupResetReplicationMarkers : IComponent { }
    
    [Game] public class ReplicationInterval : IComponent { public float Value; }
    [Game] public class MinReplicationInterval : IComponent { public float Value; }
    [Game] public class MaxReplicationInterval : IComponent { public float Value; }
    [Game] public class WaitReplicationDuration : IComponent { public float Value; }
    [Game] public class WaitReplicationTimeLeft : IComponent { public float Value; }
    [Game] public class TimeLeftForNextReplication : IComponent { public float Value; }
    [Game] public class DefaultReplicationDuration : IComponent { public float Value; }
    [Game] public class CurrentReplicationDuration : IComponent { public float Value; }
    [Game] public class ReplicationTimeLeft : IComponent { public float Value; }
    [Game] public class WaitingForNextReplicationUp : IComponent {}
    [Game] public class CanBeChosenForReplication : IComponent {}
    [Game] public class CanStartReplication : IComponent {}
    [Game] public class ReplicationTimeUp : IComponent {}
    [Game] public class ReplicationFinished : IComponent {}
    [Game] public class Replicating : IComponent {}
    [Game] public class WantToReplicate : IComponent {}
    [Game] public class ReplicationExpired : IComponent {}
    [Game] public class ReplicationTarget : IComponent { public int Value; }
    [Game] public class ChosenForReplication : IComponent {  }
    [Game] public class ChosenForReplicationBy : IComponent { public int Value; }
    [Game] public class InvalidReplicationTarget : IComponent {  }
    [Game] public class NearReplicationTarget : IComponent {  }
    [Game] public class ResetReplicationProcess : IComponent {  }
    [Game] public class WaitingReplicationTarget : IComponent {  }
    
    [Game] public class StallParentIndex : IComponent { public int Value; }
    
    [Game] public class RabbitAnimatorComponent : IComponent { public RabbitAnimator Value; }
    [Game] public class RabbitVisualChangerComponent : IComponent { public RabbitVisualChanger Value; }
    [Game] public class RabbitStateMachineComponent : IComponent { public RabbitStateMachine Value; }
    [Game] public class RabbitNextSimpleState : IComponent { public Type Value; }
    [Game] public class TransitionComplete : IComponent { }
    [Game] public class StupidMoveState : IComponent {}
    [Game] public class ReplicationState : IComponent {}
    [Game] public class DraggingState : IComponent {}
    [Game] public class IdleState : IComponent {}
    [Game] public class DeadState : IComponent {}
    [Game] public class AngryState : IComponent {}
    
    [Game] public class DeadByInfection : IComponent {}
}
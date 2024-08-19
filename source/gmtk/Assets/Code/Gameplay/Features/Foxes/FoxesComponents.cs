using Code.Gameplay.Features.Foxes.Behaviours.Animations;
using Entitas;

namespace Code.Gameplay.Features.Foxes
{
    [Game] public class Fox : IComponent {}
    [Game] public class Hungry : IComponent {}
    [Game] public class WaitingHunt : IComponent {}
    [Game] public class MovingToRandomPoint : IComponent {}
    [Game] public class HuntDuration : IComponent { public float Value; }
    [Game] public class HuntTimeLeft : IComponent { public float Value; }
    
    [Game] public class BeforeNextHuntInterval : IComponent { public float Value; }
    [Game] public class BeforeNextHuntTimeLeft : IComponent { public float Value; }

    [Game] public class HuntStarted : IComponent {}
    [Game] public class HuntFinished : IComponent {}
    [Game] public class WaitNextTarget : IComponent { }
    
    [Game] public class EatingDuration : IComponent { public float Value; }
    [Game] public class EatingTimeLeft : IComponent { public float Value; }
    [Game] public class Eating : IComponent { }
    [Game] public class EatingStarted : IComponent { }
    [Game] public class EatingFinished : IComponent { }
    [Game] public class TargetAmountToGetEnough : IComponent { public int Value; }
    [Game] public class TargetAmountGot : IComponent { public int Value; }
    
    [Game] public class FoxAnimatorComponent : IComponent { public FoxAnimator Value; }
}
using Code.Gameplay.Features.Foxes.Behaviours.Animations;
using Code.Gameplay.Features.Foxes.Behaviours.Visuals;
using Code.Gameplay.Sounds.Behaviours;
using Entitas;

namespace Code.Gameplay.Features.Foxes
{
    [Game] public class Fox : IComponent {}
    [Game] public class Hungry : IComponent {}
    [Game] public class WaitingHunt : IComponent {}
    [Game] public class MovingToHuntTarget : IComponent {}
    [Game] public class MovingToRandomPoint : IComponent {}
    [Game] public class HuntDuration : IComponent { public float Value; }
    [Game] public class HuntTimeLeft : IComponent { public float Value; }
    
    [Game] public class BeforeNextHuntInterval : IComponent { public float Value; }
    [Game] public class BeforeNextHuntTimeLeft : IComponent { public float Value; }

    [Game] public class HuntStarted : IComponent {}
    [Game] public class Hunting : IComponent {}
    [Game] public class HuntFinished : IComponent {}
    [Game] public class WaitingNextHuntTarget : IComponent { }
    [Game] public class HuntTarget : IComponent { public int Value; }
    [Game] public class ValidHuntTarget : IComponent { }
    [Game] public class InvalidHuntTarget : IComponent { }
    [Game] public class NoValidTargets : IComponent { }
    [Game] public class NearHuntTarget : IComponent { }
    
    [Game] public class EatingDuration : IComponent { public float Value; }
    [Game] public class EatingTimeLeft : IComponent { public float Value; }
    [Game] public class Eating : IComponent { }
    [Game] public class EatingStarted : IComponent { }
    [Game] public class EatingFinished : IComponent { }
    [Game] public class Eaten : IComponent { }
    [Game] public class TargetAmountToGetEnough : IComponent { public int Value; }
    [Game] public class TargetAmountGot : IComponent { public int Value; }
    [Game] public class GotEnough : IComponent { }
    [Game] public class FoxAnimatorComponent : IComponent { public FoxAnimator Value; }
    [Game] public class FoxVisualChangerComponent : IComponent { public FoxVisualChanger Value; }
    [Game] public class SickVisualChangerComponent : IComponent { public SickVisualChanger Value; }
    [Game] public class AttachedSound : IComponent { public SoundElement Value; }
}
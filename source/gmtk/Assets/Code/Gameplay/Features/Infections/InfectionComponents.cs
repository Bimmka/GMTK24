using Code.Gameplay.Features.Infections.Configs;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Infections
{
    [Game] public class Infection : IComponent {}
    [Game] public class InfectionTypeComponent : IComponent { public InfectionType Value; }
    [Game] public class PoisoningInfection : IComponent {}
    [Game] public class RabiesInfection : IComponent {}
    [Game] public class InfectionRadius : IComponent { public float Value; }
    [Game] public class ChanceToInfect : IComponent { public float Value; }
    [Game] public class InfectionInterval : IComponent { public float Value; }
    [Game] public class TimeLeftBeforeInfection : IComponent { public float Value; }
    [Game] public class InfectionUp : IComponent {}
    [Game] public class CarrierOfInfectionId : IComponent { public int Value; }
    [Game] public class CarrierOfInfection : IComponent { }
    [Game] public class CarrierOfPoisonInfection : IComponent { }
    [Game] public class CarrierOfRabiesInfection : IComponent { }
    [Game] public class LevelInfection : IComponent { }
    [Game] public class InfectionLayerMask : IComponent { public LayerMask Value; }
    [Game] public class ValidInfection : IComponent { }
    [Game] public class InfectionTrayLength : IComponent { public float Value; }
    [Game] public class InfectionTrayWidth : IComponent { public float Value; }
    
}
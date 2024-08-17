using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement
{
    [Game] public class Speed : IComponent { public float Value; }
    [Game] public class MovementAvailable : IComponent {}
    [Game] public class Moving : IComponent {}
    [Game] public class TargetPoint : IComponent { public Vector3 Value; }
    [Game] public class MoveDirection : IComponent { public Vector2 Value; }
    [Game] public class TargetPointReached : IComponent {}
    [Game] public class TurnedAlongDirection : IComponent {}
}
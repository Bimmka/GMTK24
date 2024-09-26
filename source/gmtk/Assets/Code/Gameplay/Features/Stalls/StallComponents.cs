using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Stalls
{
    [Game] public class Stall : IComponent {}
    [Game] public class StallIndex : IComponent { public int Value; }
    [Game] public class StallBounds : IComponent { public Vector2 Value; }
    [Game] public class RabbitsAmount : IComponent { public int Value; }
}
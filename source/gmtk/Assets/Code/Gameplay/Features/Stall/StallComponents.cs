using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Stall
{
    [Game] public class Stall : IComponent {}
    [Game] public class StallIndex : IComponent { public int Value; }
    [Game] public class StallBounds : IComponent { public Vector2 Value; }
}
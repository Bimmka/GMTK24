using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.ConveyorBelt
{
    [Game] public class ConveyorBelt : IComponent {}
    [Game] public class ConveyorStartPoint : IComponent { public Vector3 Value; }
    [Game] public class ConveyorEndPoint : IComponent { public Vector3 Value; }
    [Game] public class ConveyorStartStall : IComponent { public int Value; }
    [Game] public class ConveyorEndStall : IComponent { public int Value; }
    [Game] public class ElementsOnConveyor : IComponent { public List<int> Value; }
    [Game] public class ConveyorMoveDirection : IComponent { public Vector3 Value; }
    [Game] public class OnConveyorBelt : IComponent {}
    [Game] public class ConveyoringStarted : IComponent {}
    [Game] public class ConveyoringFinished : IComponent {}
    [Game] public class ParentConveyorBeltId : IComponent { public int Value; }
}
using System.Collections.Generic;
using Code.Gameplay.Features.Holes.Config;
using Entitas;

namespace Code.Gameplay.Features.Holes
{
    [Game] public class Hole : IComponent {}
    [Game] public class SpawnUp : IComponent {}
    [Game] public class SpawnInterval : IComponent { public float Value; }
    [Game] public class SpawnTimeLeft : IComponent { public float Value; }
    [Game] public class HoleEntitySpawnDataComponent : IComponent { public List<HoleEntitySpawnData> Value; }
    [Game] public class SpawnAmount : IComponent { public int Value; }
}

using Entitas;
using UnityEngine;

namespace Code.Gameplay.Common
{
    [Game] public class TransformComponent : IComponent { public Transform Value; }
    [Game] public class ParentTransform : IComponent { public Transform Value; }
    [Game] public class WorldPosition : IComponent { public Vector3 Value; }
    [Game] public class SaveRotationInSpawn : IComponent { }
}
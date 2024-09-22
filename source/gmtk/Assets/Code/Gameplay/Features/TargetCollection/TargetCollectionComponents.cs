using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.TargetCollection
{
  [Game] public class ReadyToCollectTargets : IComponent { }
  [Game] public class CollectingTargetsContinuously : IComponent { }
  [Game] public class TargetBuffer : IComponent { public List<int> Value; }
  [Game] public class ProcessedTargets : IComponent { public List<int> Value; }
  
  [Game] public class CollectTargetsInterval : IComponent { public float Value; }
  [Game] public class CollectTargetsTimeLeft : IComponent { public float Value; }
  
  [Game] public class TargetCollectionLayerMask : IComponent { public int Value; }
  [Game] public class TargetLimit : IComponent { public int Value; }
  [Game] public class TargetCollectionCastPoint : IComponent { public Vector3 Value; }
}
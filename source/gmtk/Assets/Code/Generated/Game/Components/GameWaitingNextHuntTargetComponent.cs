//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherWaitingNextHuntTarget;

    public static Entitas.IMatcher<GameEntity> WaitingNextHuntTarget {
        get {
            if (_matcherWaitingNextHuntTarget == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.WaitingNextHuntTarget);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherWaitingNextHuntTarget = matcher;
            }

            return _matcherWaitingNextHuntTarget;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly Code.Gameplay.Features.Foxes.WaitingNextHuntTarget waitingNextHuntTargetComponent = new Code.Gameplay.Features.Foxes.WaitingNextHuntTarget();

    public bool isWaitingNextHuntTarget {
        get { return HasComponent(GameComponentsLookup.WaitingNextHuntTarget); }
        set {
            if (value != isWaitingNextHuntTarget) {
                var index = GameComponentsLookup.WaitingNextHuntTarget;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : waitingNextHuntTargetComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

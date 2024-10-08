//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherValidReplicationTarget;

    public static Entitas.IMatcher<GameEntity> ValidReplicationTarget {
        get {
            if (_matcherValidReplicationTarget == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ValidReplicationTarget);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherValidReplicationTarget = matcher;
            }

            return _matcherValidReplicationTarget;
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

    static readonly Code.Gameplay.Features.Rabbits.ValidReplicationTarget validReplicationTargetComponent = new Code.Gameplay.Features.Rabbits.ValidReplicationTarget();

    public bool isValidReplicationTarget {
        get { return HasComponent(GameComponentsLookup.ValidReplicationTarget); }
        set {
            if (value != isValidReplicationTarget) {
                var index = GameComponentsLookup.ValidReplicationTarget;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : validReplicationTargetComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherInvalidHuntTarget;

    public static Entitas.IMatcher<GameEntity> InvalidHuntTarget {
        get {
            if (_matcherInvalidHuntTarget == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.InvalidHuntTarget);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherInvalidHuntTarget = matcher;
            }

            return _matcherInvalidHuntTarget;
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

    static readonly Code.Gameplay.Features.Foxes.InvalidHuntTarget invalidHuntTargetComponent = new Code.Gameplay.Features.Foxes.InvalidHuntTarget();

    public bool isInvalidHuntTarget {
        get { return HasComponent(GameComponentsLookup.InvalidHuntTarget); }
        set {
            if (value != isInvalidHuntTarget) {
                var index = GameComponentsLookup.InvalidHuntTarget;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : invalidHuntTargetComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
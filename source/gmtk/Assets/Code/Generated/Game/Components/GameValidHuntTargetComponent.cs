//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherValidHuntTarget;

    public static Entitas.IMatcher<GameEntity> ValidHuntTarget {
        get {
            if (_matcherValidHuntTarget == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ValidHuntTarget);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherValidHuntTarget = matcher;
            }

            return _matcherValidHuntTarget;
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

    static readonly Code.Gameplay.Features.Foxes.ValidHuntTarget validHuntTargetComponent = new Code.Gameplay.Features.Foxes.ValidHuntTarget();

    public bool isValidHuntTarget {
        get { return HasComponent(GameComponentsLookup.ValidHuntTarget); }
        set {
            if (value != isValidHuntTarget) {
                var index = GameComponentsLookup.ValidHuntTarget;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : validHuntTargetComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

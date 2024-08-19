//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherValidStatus;

    public static Entitas.IMatcher<GameEntity> ValidStatus {
        get {
            if (_matcherValidStatus == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ValidStatus);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherValidStatus = matcher;
            }

            return _matcherValidStatus;
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

    static readonly Code.Gameplay.Features.Statuses.ValidStatus validStatusComponent = new Code.Gameplay.Features.Statuses.ValidStatus();

    public bool isValidStatus {
        get { return HasComponent(GameComponentsLookup.ValidStatus); }
        set {
            if (value != isValidStatus) {
                var index = GameComponentsLookup.ValidStatus;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : validStatusComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherUnselectSelectedEntities;

    public static Entitas.IMatcher<GameEntity> UnselectSelectedEntities {
        get {
            if (_matcherUnselectSelectedEntities == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.UnselectSelectedEntities);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherUnselectSelectedEntities = matcher;
            }

            return _matcherUnselectSelectedEntities;
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

    static readonly Code.Gameplay.Features.Selection.UnselectSelectedEntities unselectSelectedEntitiesComponent = new Code.Gameplay.Features.Selection.UnselectSelectedEntities();

    public bool isUnselectSelectedEntities {
        get { return HasComponent(GameComponentsLookup.UnselectSelectedEntities); }
        set {
            if (value != isUnselectSelectedEntities) {
                var index = GameComponentsLookup.UnselectSelectedEntities;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : unselectSelectedEntitiesComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

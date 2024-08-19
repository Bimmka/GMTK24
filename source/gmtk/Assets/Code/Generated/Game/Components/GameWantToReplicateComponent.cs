//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherWantToReplicate;

    public static Entitas.IMatcher<GameEntity> WantToReplicate {
        get {
            if (_matcherWantToReplicate == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.WantToReplicate);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherWantToReplicate = matcher;
            }

            return _matcherWantToReplicate;
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

    static readonly Code.Gameplay.Features.Rabbits.WantToReplicate wantToReplicateComponent = new Code.Gameplay.Features.Rabbits.WantToReplicate();

    public bool isWantToReplicate {
        get { return HasComponent(GameComponentsLookup.WantToReplicate); }
        set {
            if (value != isWantToReplicate) {
                var index = GameComponentsLookup.WantToReplicate;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : wantToReplicateComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherDeadState;

    public static Entitas.IMatcher<GameEntity> DeadState {
        get {
            if (_matcherDeadState == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.DeadState);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDeadState = matcher;
            }

            return _matcherDeadState;
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

    static readonly Code.Gameplay.Features.Rabbits.DeadState deadStateComponent = new Code.Gameplay.Features.Rabbits.DeadState();

    public bool isDeadState {
        get { return HasComponent(GameComponentsLookup.DeadState); }
        set {
            if (value != isDeadState) {
                var index = GameComponentsLookup.DeadState;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : deadStateComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
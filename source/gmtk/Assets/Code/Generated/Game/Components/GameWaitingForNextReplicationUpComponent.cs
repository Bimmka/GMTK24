//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherWaitingForNextReplicationUp;

    public static Entitas.IMatcher<GameEntity> WaitingForNextReplicationUp {
        get {
            if (_matcherWaitingForNextReplicationUp == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.WaitingForNextReplicationUp);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherWaitingForNextReplicationUp = matcher;
            }

            return _matcherWaitingForNextReplicationUp;
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

    static readonly Code.Gameplay.Features.Rabbits.WaitingForNextReplicationUp waitingForNextReplicationUpComponent = new Code.Gameplay.Features.Rabbits.WaitingForNextReplicationUp();

    public bool isWaitingForNextReplicationUp {
        get { return HasComponent(GameComponentsLookup.WaitingForNextReplicationUp); }
        set {
            if (value != isWaitingForNextReplicationUp) {
                var index = GameComponentsLookup.WaitingForNextReplicationUp;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : waitingForNextReplicationUpComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

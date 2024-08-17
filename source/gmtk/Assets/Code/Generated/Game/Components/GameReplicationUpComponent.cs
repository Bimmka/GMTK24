//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherReplicationUp;

    public static Entitas.IMatcher<GameEntity> ReplicationUp {
        get {
            if (_matcherReplicationUp == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ReplicationUp);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherReplicationUp = matcher;
            }

            return _matcherReplicationUp;
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

    static readonly Code.Gameplay.Features.Rabbits.ReplicationUp replicationUpComponent = new Code.Gameplay.Features.Rabbits.ReplicationUp();

    public bool isReplicationUp {
        get { return HasComponent(GameComponentsLookup.ReplicationUp); }
        set {
            if (value != isReplicationUp) {
                var index = GameComponentsLookup.ReplicationUp;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : replicationUpComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
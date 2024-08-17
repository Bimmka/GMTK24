//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherReplicationInterval;

    public static Entitas.IMatcher<GameEntity> ReplicationInterval {
        get {
            if (_matcherReplicationInterval == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ReplicationInterval);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherReplicationInterval = matcher;
            }

            return _matcherReplicationInterval;
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

    public Code.Gameplay.Features.Rabbits.ReplicationInterval replicationInterval { get { return (Code.Gameplay.Features.Rabbits.ReplicationInterval)GetComponent(GameComponentsLookup.ReplicationInterval); } }
    public float ReplicationInterval { get { return replicationInterval.Value; } }
    public bool hasReplicationInterval { get { return HasComponent(GameComponentsLookup.ReplicationInterval); } }

    public GameEntity AddReplicationInterval(float newValue) {
        var index = GameComponentsLookup.ReplicationInterval;
        var component = (Code.Gameplay.Features.Rabbits.ReplicationInterval)CreateComponent(index, typeof(Code.Gameplay.Features.Rabbits.ReplicationInterval));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceReplicationInterval(float newValue) {
        var index = GameComponentsLookup.ReplicationInterval;
        var component = (Code.Gameplay.Features.Rabbits.ReplicationInterval)CreateComponent(index, typeof(Code.Gameplay.Features.Rabbits.ReplicationInterval));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveReplicationInterval() {
        RemoveComponent(GameComponentsLookup.ReplicationInterval);
        return this;
    }
}
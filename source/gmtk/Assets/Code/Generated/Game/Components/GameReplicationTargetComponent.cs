//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherReplicationTarget;

    public static Entitas.IMatcher<GameEntity> ReplicationTarget {
        get {
            if (_matcherReplicationTarget == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ReplicationTarget);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherReplicationTarget = matcher;
            }

            return _matcherReplicationTarget;
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

    public Code.Gameplay.Features.Rabbits.ReplicationTarget replicationTarget { get { return (Code.Gameplay.Features.Rabbits.ReplicationTarget)GetComponent(GameComponentsLookup.ReplicationTarget); } }
    public int ReplicationTarget { get { return replicationTarget.Value; } }
    public bool hasReplicationTarget { get { return HasComponent(GameComponentsLookup.ReplicationTarget); } }

    public GameEntity AddReplicationTarget(int newValue) {
        var index = GameComponentsLookup.ReplicationTarget;
        var component = (Code.Gameplay.Features.Rabbits.ReplicationTarget)CreateComponent(index, typeof(Code.Gameplay.Features.Rabbits.ReplicationTarget));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceReplicationTarget(int newValue) {
        var index = GameComponentsLookup.ReplicationTarget;
        var component = (Code.Gameplay.Features.Rabbits.ReplicationTarget)CreateComponent(index, typeof(Code.Gameplay.Features.Rabbits.ReplicationTarget));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveReplicationTarget() {
        RemoveComponent(GameComponentsLookup.ReplicationTarget);
        return this;
    }
}

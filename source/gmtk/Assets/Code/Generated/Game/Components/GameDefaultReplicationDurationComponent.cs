//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherDefaultReplicationDuration;

    public static Entitas.IMatcher<GameEntity> DefaultReplicationDuration {
        get {
            if (_matcherDefaultReplicationDuration == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.DefaultReplicationDuration);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDefaultReplicationDuration = matcher;
            }

            return _matcherDefaultReplicationDuration;
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

    public Code.Gameplay.Features.Rabbits.DefaultReplicationDuration defaultReplicationDuration { get { return (Code.Gameplay.Features.Rabbits.DefaultReplicationDuration)GetComponent(GameComponentsLookup.DefaultReplicationDuration); } }
    public float DefaultReplicationDuration { get { return defaultReplicationDuration.Value; } }
    public bool hasDefaultReplicationDuration { get { return HasComponent(GameComponentsLookup.DefaultReplicationDuration); } }

    public GameEntity AddDefaultReplicationDuration(float newValue) {
        var index = GameComponentsLookup.DefaultReplicationDuration;
        var component = (Code.Gameplay.Features.Rabbits.DefaultReplicationDuration)CreateComponent(index, typeof(Code.Gameplay.Features.Rabbits.DefaultReplicationDuration));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceDefaultReplicationDuration(float newValue) {
        var index = GameComponentsLookup.DefaultReplicationDuration;
        var component = (Code.Gameplay.Features.Rabbits.DefaultReplicationDuration)CreateComponent(index, typeof(Code.Gameplay.Features.Rabbits.DefaultReplicationDuration));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveDefaultReplicationDuration() {
        RemoveComponent(GameComponentsLookup.DefaultReplicationDuration);
        return this;
    }
}

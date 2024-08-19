//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherSpawnInterval;

    public static Entitas.IMatcher<GameEntity> SpawnInterval {
        get {
            if (_matcherSpawnInterval == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.SpawnInterval);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSpawnInterval = matcher;
            }

            return _matcherSpawnInterval;
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

    public Code.Gameplay.Features.Holes.SpawnInterval spawnInterval { get { return (Code.Gameplay.Features.Holes.SpawnInterval)GetComponent(GameComponentsLookup.SpawnInterval); } }
    public float SpawnInterval { get { return spawnInterval.Value; } }
    public bool hasSpawnInterval { get { return HasComponent(GameComponentsLookup.SpawnInterval); } }

    public GameEntity AddSpawnInterval(float newValue) {
        var index = GameComponentsLookup.SpawnInterval;
        var component = (Code.Gameplay.Features.Holes.SpawnInterval)CreateComponent(index, typeof(Code.Gameplay.Features.Holes.SpawnInterval));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceSpawnInterval(float newValue) {
        var index = GameComponentsLookup.SpawnInterval;
        var component = (Code.Gameplay.Features.Holes.SpawnInterval)CreateComponent(index, typeof(Code.Gameplay.Features.Holes.SpawnInterval));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveSpawnInterval() {
        RemoveComponent(GameComponentsLookup.SpawnInterval);
        return this;
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherHoleEntitySpawnData;

    public static Entitas.IMatcher<GameEntity> HoleEntitySpawnData {
        get {
            if (_matcherHoleEntitySpawnData == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.HoleEntitySpawnData);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherHoleEntitySpawnData = matcher;
            }

            return _matcherHoleEntitySpawnData;
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

    public Code.Gameplay.Features.Holes.HoleEntitySpawnDataComponent holeEntitySpawnData { get { return (Code.Gameplay.Features.Holes.HoleEntitySpawnDataComponent)GetComponent(GameComponentsLookup.HoleEntitySpawnData); } }
    public System.Collections.Generic.List<Code.Gameplay.Features.Holes.Config.HoleEntitySpawnData> HoleEntitySpawnData { get { return holeEntitySpawnData.Value; } }
    public bool hasHoleEntitySpawnData { get { return HasComponent(GameComponentsLookup.HoleEntitySpawnData); } }

    public GameEntity AddHoleEntitySpawnData(System.Collections.Generic.List<Code.Gameplay.Features.Holes.Config.HoleEntitySpawnData> newValue) {
        var index = GameComponentsLookup.HoleEntitySpawnData;
        var component = (Code.Gameplay.Features.Holes.HoleEntitySpawnDataComponent)CreateComponent(index, typeof(Code.Gameplay.Features.Holes.HoleEntitySpawnDataComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceHoleEntitySpawnData(System.Collections.Generic.List<Code.Gameplay.Features.Holes.Config.HoleEntitySpawnData> newValue) {
        var index = GameComponentsLookup.HoleEntitySpawnData;
        var component = (Code.Gameplay.Features.Holes.HoleEntitySpawnDataComponent)CreateComponent(index, typeof(Code.Gameplay.Features.Holes.HoleEntitySpawnDataComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveHoleEntitySpawnData() {
        RemoveComponent(GameComponentsLookup.HoleEntitySpawnData);
        return this;
    }
}

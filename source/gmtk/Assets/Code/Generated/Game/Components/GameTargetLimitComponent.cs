//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherTargetLimit;

    public static Entitas.IMatcher<GameEntity> TargetLimit {
        get {
            if (_matcherTargetLimit == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.TargetLimit);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTargetLimit = matcher;
            }

            return _matcherTargetLimit;
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

    public Code.Gameplay.Features.TargetCollection.TargetLimit targetLimit { get { return (Code.Gameplay.Features.TargetCollection.TargetLimit)GetComponent(GameComponentsLookup.TargetLimit); } }
    public int TargetLimit { get { return targetLimit.Value; } }
    public bool hasTargetLimit { get { return HasComponent(GameComponentsLookup.TargetLimit); } }

    public GameEntity AddTargetLimit(int newValue) {
        var index = GameComponentsLookup.TargetLimit;
        var component = (Code.Gameplay.Features.TargetCollection.TargetLimit)CreateComponent(index, typeof(Code.Gameplay.Features.TargetCollection.TargetLimit));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceTargetLimit(int newValue) {
        var index = GameComponentsLookup.TargetLimit;
        var component = (Code.Gameplay.Features.TargetCollection.TargetLimit)CreateComponent(index, typeof(Code.Gameplay.Features.TargetCollection.TargetLimit));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveTargetLimit() {
        RemoveComponent(GameComponentsLookup.TargetLimit);
        return this;
    }
}

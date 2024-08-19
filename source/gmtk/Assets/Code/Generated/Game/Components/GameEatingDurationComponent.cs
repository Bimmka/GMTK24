//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherEatingDuration;

    public static Entitas.IMatcher<GameEntity> EatingDuration {
        get {
            if (_matcherEatingDuration == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.EatingDuration);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherEatingDuration = matcher;
            }

            return _matcherEatingDuration;
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

    public Code.Gameplay.Features.Foxes.EatingDuration eatingDuration { get { return (Code.Gameplay.Features.Foxes.EatingDuration)GetComponent(GameComponentsLookup.EatingDuration); } }
    public float EatingDuration { get { return eatingDuration.Value; } }
    public bool hasEatingDuration { get { return HasComponent(GameComponentsLookup.EatingDuration); } }

    public GameEntity AddEatingDuration(float newValue) {
        var index = GameComponentsLookup.EatingDuration;
        var component = (Code.Gameplay.Features.Foxes.EatingDuration)CreateComponent(index, typeof(Code.Gameplay.Features.Foxes.EatingDuration));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceEatingDuration(float newValue) {
        var index = GameComponentsLookup.EatingDuration;
        var component = (Code.Gameplay.Features.Foxes.EatingDuration)CreateComponent(index, typeof(Code.Gameplay.Features.Foxes.EatingDuration));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveEatingDuration() {
        RemoveComponent(GameComponentsLookup.EatingDuration);
        return this;
    }
}

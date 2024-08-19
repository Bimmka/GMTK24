//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherLevelTaskHoldDuration;

    public static Entitas.IMatcher<GameEntity> LevelTaskHoldDuration {
        get {
            if (_matcherLevelTaskHoldDuration == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LevelTaskHoldDuration);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLevelTaskHoldDuration = matcher;
            }

            return _matcherLevelTaskHoldDuration;
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

    public Code.Gameplay.Features.LevelTasks.LevelTaskHoldDuration levelTaskHoldDuration { get { return (Code.Gameplay.Features.LevelTasks.LevelTaskHoldDuration)GetComponent(GameComponentsLookup.LevelTaskHoldDuration); } }
    public float LevelTaskHoldDuration { get { return levelTaskHoldDuration.Value; } }
    public bool hasLevelTaskHoldDuration { get { return HasComponent(GameComponentsLookup.LevelTaskHoldDuration); } }

    public GameEntity AddLevelTaskHoldDuration(float newValue) {
        var index = GameComponentsLookup.LevelTaskHoldDuration;
        var component = (Code.Gameplay.Features.LevelTasks.LevelTaskHoldDuration)CreateComponent(index, typeof(Code.Gameplay.Features.LevelTasks.LevelTaskHoldDuration));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceLevelTaskHoldDuration(float newValue) {
        var index = GameComponentsLookup.LevelTaskHoldDuration;
        var component = (Code.Gameplay.Features.LevelTasks.LevelTaskHoldDuration)CreateComponent(index, typeof(Code.Gameplay.Features.LevelTasks.LevelTaskHoldDuration));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveLevelTaskHoldDuration() {
        RemoveComponent(GameComponentsLookup.LevelTaskHoldDuration);
        return this;
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherLevelTaskTargetHoldDuration;

    public static Entitas.IMatcher<GameEntity> LevelTaskTargetHoldDuration {
        get {
            if (_matcherLevelTaskTargetHoldDuration == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LevelTaskTargetHoldDuration);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLevelTaskTargetHoldDuration = matcher;
            }

            return _matcherLevelTaskTargetHoldDuration;
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

    public Code.Gameplay.Features.LevelTasks.LevelTaskTargetHoldDuration levelTaskTargetHoldDuration { get { return (Code.Gameplay.Features.LevelTasks.LevelTaskTargetHoldDuration)GetComponent(GameComponentsLookup.LevelTaskTargetHoldDuration); } }
    public float LevelTaskTargetHoldDuration { get { return levelTaskTargetHoldDuration.Value; } }
    public bool hasLevelTaskTargetHoldDuration { get { return HasComponent(GameComponentsLookup.LevelTaskTargetHoldDuration); } }

    public GameEntity AddLevelTaskTargetHoldDuration(float newValue) {
        var index = GameComponentsLookup.LevelTaskTargetHoldDuration;
        var component = (Code.Gameplay.Features.LevelTasks.LevelTaskTargetHoldDuration)CreateComponent(index, typeof(Code.Gameplay.Features.LevelTasks.LevelTaskTargetHoldDuration));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceLevelTaskTargetHoldDuration(float newValue) {
        var index = GameComponentsLookup.LevelTaskTargetHoldDuration;
        var component = (Code.Gameplay.Features.LevelTasks.LevelTaskTargetHoldDuration)CreateComponent(index, typeof(Code.Gameplay.Features.LevelTasks.LevelTaskTargetHoldDuration));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveLevelTaskTargetHoldDuration() {
        RemoveComponent(GameComponentsLookup.LevelTaskTargetHoldDuration);
        return this;
    }
}

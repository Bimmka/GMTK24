//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherLevelTaskHoldDurationTime;

    public static Entitas.IMatcher<GameEntity> LevelTaskHoldDurationTime {
        get {
            if (_matcherLevelTaskHoldDurationTime == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LevelTaskHoldDurationTime);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLevelTaskHoldDurationTime = matcher;
            }

            return _matcherLevelTaskHoldDurationTime;
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

    public Code.Gameplay.Features.LevelTasks.LevelTaskHoldDurationTime levelTaskHoldDurationTime { get { return (Code.Gameplay.Features.LevelTasks.LevelTaskHoldDurationTime)GetComponent(GameComponentsLookup.LevelTaskHoldDurationTime); } }
    public float LevelTaskHoldDurationTime { get { return levelTaskHoldDurationTime.Value; } }
    public bool hasLevelTaskHoldDurationTime { get { return HasComponent(GameComponentsLookup.LevelTaskHoldDurationTime); } }

    public GameEntity AddLevelTaskHoldDurationTime(float newValue) {
        var index = GameComponentsLookup.LevelTaskHoldDurationTime;
        var component = (Code.Gameplay.Features.LevelTasks.LevelTaskHoldDurationTime)CreateComponent(index, typeof(Code.Gameplay.Features.LevelTasks.LevelTaskHoldDurationTime));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceLevelTaskHoldDurationTime(float newValue) {
        var index = GameComponentsLookup.LevelTaskHoldDurationTime;
        var component = (Code.Gameplay.Features.LevelTasks.LevelTaskHoldDurationTime)CreateComponent(index, typeof(Code.Gameplay.Features.LevelTasks.LevelTaskHoldDurationTime));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveLevelTaskHoldDurationTime() {
        RemoveComponent(GameComponentsLookup.LevelTaskHoldDurationTime);
        return this;
    }
}

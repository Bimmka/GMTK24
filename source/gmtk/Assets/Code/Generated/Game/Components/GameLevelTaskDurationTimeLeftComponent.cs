//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherLevelTaskDurationTimeLeft;

    public static Entitas.IMatcher<GameEntity> LevelTaskDurationTimeLeft {
        get {
            if (_matcherLevelTaskDurationTimeLeft == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LevelTaskDurationTimeLeft);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLevelTaskDurationTimeLeft = matcher;
            }

            return _matcherLevelTaskDurationTimeLeft;
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

    public Code.Gameplay.Features.LevelTasks.LevelTaskDurationTimeLeft levelTaskDurationTimeLeft { get { return (Code.Gameplay.Features.LevelTasks.LevelTaskDurationTimeLeft)GetComponent(GameComponentsLookup.LevelTaskDurationTimeLeft); } }
    public float LevelTaskDurationTimeLeft { get { return levelTaskDurationTimeLeft.Value; } }
    public bool hasLevelTaskDurationTimeLeft { get { return HasComponent(GameComponentsLookup.LevelTaskDurationTimeLeft); } }

    public GameEntity AddLevelTaskDurationTimeLeft(float newValue) {
        var index = GameComponentsLookup.LevelTaskDurationTimeLeft;
        var component = (Code.Gameplay.Features.LevelTasks.LevelTaskDurationTimeLeft)CreateComponent(index, typeof(Code.Gameplay.Features.LevelTasks.LevelTaskDurationTimeLeft));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceLevelTaskDurationTimeLeft(float newValue) {
        var index = GameComponentsLookup.LevelTaskDurationTimeLeft;
        var component = (Code.Gameplay.Features.LevelTasks.LevelTaskDurationTimeLeft)CreateComponent(index, typeof(Code.Gameplay.Features.LevelTasks.LevelTaskDurationTimeLeft));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveLevelTaskDurationTimeLeft() {
        RemoveComponent(GameComponentsLookup.LevelTaskDurationTimeLeft);
        return this;
    }
}

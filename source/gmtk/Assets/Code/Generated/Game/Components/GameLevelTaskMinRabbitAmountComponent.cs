//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherLevelTaskMinRabbitAmount;

    public static Entitas.IMatcher<GameEntity> LevelTaskMinRabbitAmount {
        get {
            if (_matcherLevelTaskMinRabbitAmount == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LevelTaskMinRabbitAmount);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLevelTaskMinRabbitAmount = matcher;
            }

            return _matcherLevelTaskMinRabbitAmount;
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

    public Code.Gameplay.Features.LevelTasks.LevelTaskMinRabbitAmount levelTaskMinRabbitAmount { get { return (Code.Gameplay.Features.LevelTasks.LevelTaskMinRabbitAmount)GetComponent(GameComponentsLookup.LevelTaskMinRabbitAmount); } }
    public int LevelTaskMinRabbitAmount { get { return levelTaskMinRabbitAmount.Value; } }
    public bool hasLevelTaskMinRabbitAmount { get { return HasComponent(GameComponentsLookup.LevelTaskMinRabbitAmount); } }

    public GameEntity AddLevelTaskMinRabbitAmount(int newValue) {
        var index = GameComponentsLookup.LevelTaskMinRabbitAmount;
        var component = (Code.Gameplay.Features.LevelTasks.LevelTaskMinRabbitAmount)CreateComponent(index, typeof(Code.Gameplay.Features.LevelTasks.LevelTaskMinRabbitAmount));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceLevelTaskMinRabbitAmount(int newValue) {
        var index = GameComponentsLookup.LevelTaskMinRabbitAmount;
        var component = (Code.Gameplay.Features.LevelTasks.LevelTaskMinRabbitAmount)CreateComponent(index, typeof(Code.Gameplay.Features.LevelTasks.LevelTaskMinRabbitAmount));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveLevelTaskMinRabbitAmount() {
        RemoveComponent(GameComponentsLookup.LevelTaskMinRabbitAmount);
        return this;
    }
}

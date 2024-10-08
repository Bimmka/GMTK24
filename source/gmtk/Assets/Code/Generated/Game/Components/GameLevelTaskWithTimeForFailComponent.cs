//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherLevelTaskWithTimeForFail;

    public static Entitas.IMatcher<GameEntity> LevelTaskWithTimeForFail {
        get {
            if (_matcherLevelTaskWithTimeForFail == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LevelTaskWithTimeForFail);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLevelTaskWithTimeForFail = matcher;
            }

            return _matcherLevelTaskWithTimeForFail;
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

    static readonly Code.Gameplay.Features.LevelTasks.LevelTaskWithTimeForFail levelTaskWithTimeForFailComponent = new Code.Gameplay.Features.LevelTasks.LevelTaskWithTimeForFail();

    public bool isLevelTaskWithTimeForFail {
        get { return HasComponent(GameComponentsLookup.LevelTaskWithTimeForFail); }
        set {
            if (value != isLevelTaskWithTimeForFail) {
                var index = GameComponentsLookup.LevelTaskWithTimeForFail;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : levelTaskWithTimeForFailComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

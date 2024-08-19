//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherTimeConditionCompleted;

    public static Entitas.IMatcher<GameEntity> TimeConditionCompleted {
        get {
            if (_matcherTimeConditionCompleted == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.TimeConditionCompleted);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTimeConditionCompleted = matcher;
            }

            return _matcherTimeConditionCompleted;
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

    static readonly Code.Gameplay.Features.LevelTasks.TimeConditionCompleted timeConditionCompletedComponent = new Code.Gameplay.Features.LevelTasks.TimeConditionCompleted();

    public bool isTimeConditionCompleted {
        get { return HasComponent(GameComponentsLookup.TimeConditionCompleted); }
        set {
            if (value != isTimeConditionCompleted) {
                var index = GameComponentsLookup.TimeConditionCompleted;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : timeConditionCompletedComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
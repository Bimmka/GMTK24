//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherTimeDurationConditionFailed;

    public static Entitas.IMatcher<GameEntity> TimeDurationConditionFailed {
        get {
            if (_matcherTimeDurationConditionFailed == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.TimeDurationConditionFailed);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTimeDurationConditionFailed = matcher;
            }

            return _matcherTimeDurationConditionFailed;
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

    static readonly Code.Gameplay.Features.LevelTasks.TimeDurationConditionFailed timeDurationConditionFailedComponent = new Code.Gameplay.Features.LevelTasks.TimeDurationConditionFailed();

    public bool isTimeDurationConditionFailed {
        get { return HasComponent(GameComponentsLookup.TimeDurationConditionFailed); }
        set {
            if (value != isTimeDurationConditionFailed) {
                var index = GameComponentsLookup.TimeDurationConditionFailed;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : timeDurationConditionFailedComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
